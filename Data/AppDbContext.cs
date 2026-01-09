using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BlazorCurseach.Models;

namespace BlazorCurseach.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CharacteristicItem> CharacteristicItems { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItemTemp> OrderItemTemps { get; set; }

    public virtual DbSet<ItemCharacteristicValue> ItemCharacteristicValues { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<ValueCharacteristic> ValuesCharacteristic { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_520_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.idCategory).HasName("PRIMARY");

            entity.ToTable("Category", tb => tb.HasComment("Категория товара"));

            entity.Property(e => e.idCategory).HasComment("Идентификатор категории");
            entity.Property(e => e.nameCategory)
                .HasMaxLength(60)
                .HasComment("Название категории товаров");
        });

        modelBuilder.Entity<CharacteristicItem>(entity =>
        {
            entity.HasKey(e => e.idCharacteristicItem).HasName("PRIMARY");

            entity.ToTable("CharacteristicItem", tb => tb.HasComment("Характеристика товара"));

            entity.HasIndex(e => e.idCategory, "fk_CharacteristicItem_Category1_idx");

            entity.Property(e => e.idCharacteristicItem).HasComment("Идентификатор характеристики товара");
            entity.Property(e => e.idCategory).HasComment("Айди категории (FK)");
            entity.Property(e => e.nameCharacteristicItem)
                .HasMaxLength(60)
                .HasComment("Название характеристики");

            entity.HasOne(d => d.idCategoryNavigation).WithMany(p => p.CharacteristicItems)
                .HasForeignKey(d => d.idCategory)
                .HasConstraintName("fk_CharacteristicItem_Category1_idx");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.idClient).HasName("PRIMARY");

            entity.ToTable("Client", tb => tb.HasComment("Клиент веб-приложения (Пользователь)"));

            entity.HasIndex(e => e.login, "login_UNIQUE").IsUnique();

            entity.Property(e => e.idClient).HasComment("Идентификатор клиента");
            entity.Property(e => e.email)
                .HasMaxLength(50)
                .HasComment("Электронная почта клиента");
            entity.Property(e => e.fatherName)
                .HasMaxLength(45)
                .HasComment("Отчество клиента");
            entity.Property(e => e.firstName)
                .HasMaxLength(45)
                .HasComment("Имя клиента");
            entity.Property(e => e.lastName)
                .HasMaxLength(45)
                .HasComment("Фамилия клиента");
            entity.Property(e => e.login)
                .HasMaxLength(45)
                .HasComment("Логин клиента");
            entity.Property(e => e.password)
                .HasMaxLength(45)
                .HasComment("Пароль клиента");
            entity.Property(e => e.phone)
                .HasMaxLength(12)
                .HasComment("Телефон клиента");
            entity.Property(e => e.idRole)
                .HasMaxLength(45)
                .HasComment("Айди роли конкретного клиента");;

            entity.HasOne(d => d.idUserRoleNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.idRole);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.idRole);

            entity.ToTable("UserRole");

            entity.Property(e => e.idRole).HasComment("Идентификатор роли пользователя");
            entity.Property(e => e.nameRole)
                .HasMaxLength(45)
                .HasComment("Название роли");
        });

        modelBuilder.Entity<ValueCharacteristic>(entity =>
        {
            entity.HasKey(e => e.idValueCharacteristic).HasName("PRIMARY");

            entity.ToTable("ValueCharacteristic", tb => tb.HasComment("Значение характеристики товара"));

            entity.Property(e => e.idValueCharacteristic).HasComment("Идентификатор значения характеристики");
            entity.Property(e => e.selfValue)
                .HasMaxLength(45)
                .HasComment("Само значение характеристики (Spell Power = 15%)");
            entity.Property(e => e.idCharacteristicItem).HasComment("Айди характеристики (FK)");

            entity.HasOne(d => d.idCharacteristicItemNavigation).WithMany(p => p.ValuesCharacteristic)
                .HasForeignKey(d => d.idCharacteristicItem);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.idItem).HasName("PRIMARY");

            entity.ToTable("Item", tb => tb.HasComment("Товар"));

            entity.HasIndex(e => e.idCategory, "fk_Item_Category1_idx");

            entity.Property(e => e.idItem).HasComment("Идентификатор товара");
            entity.Property(e => e.countItem).HasComment("Доступное количество товаров");
            entity.Property(e => e.descItem)
                .HasMaxLength(400)
                .HasComment("Описание товара");
            entity.Property(e => e.idCategory).HasComment("Идентификатор категории товара (FK)");
            entity.Property(e => e.inCart).HasComment("Флаг, определяющий, в корзине ли товар (по умолчанию false)");
            entity.Property(e => e.nameItem)
                .HasMaxLength(70)
                .HasComment("Название товара");
            entity.Property(e => e.price).HasComment("Цена товара");
            entity.Property(e => e.imageLink)
                .HasMaxLength(100)
                .HasComment("Ссылка на изображение товара в приложении");

            entity.HasOne(d => d.idCategoryNavigation).WithMany(p => p.Items)
                .HasForeignKey(d => d.idCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Item_Category1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.idOrder).HasName("PRIMARY");

            entity.ToTable("Order", tb => tb.HasComment("Заказ"));

            entity.HasIndex(e => e.idClient, "fk_Order_Client1_idx");

            entity.HasIndex(e => e.idStatusOrder, "fk_Order_StatusOrder_idx");

            entity.Property(e => e.idOrder).HasComment("Идентификатор заказа");
            entity.Property(e => e.dateCreated)
                .HasComment("Дата создания заказа")
                .HasColumnType("datetime");
            entity.Property(e => e.descOrder)
                .HasMaxLength(400)
                .HasComment("Описание заказа");
            entity.Property(e => e.idClient).HasComment("Айди клиента (FK)");
            entity.Property(e => e.idStatusOrder).HasComment("Идентификатор статуса заказа (FK)");

            entity.HasOne(d => d.idClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.idClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Order_Client1");

            entity.HasOne(d => d.idStatusOrderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.idStatusOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Order_StatusOrder");
        });

        modelBuilder.Entity<OrderItemTemp>(entity =>
        {
            entity.HasKey(e => e.idOrderItemTemp).HasName("PRIMARY");
            entity.ToTable("OrderItemTemp", tb => tb.HasComment("Таблица для обеспечения связи N:M (Item <-> Order)"));

            entity.HasIndex(e => e.idItem, "fk_table1_Item1_idx");

            entity.HasIndex(e => e.idOrder, "fk_table1_Order1_idx");

            entity.Property(e => e.idOrderItemTemp)
                .HasComment("Идентификатор связующей таблицы заказа и товара");

            entity.Property(e => e.idItem).HasComment("Айди товара для связи M:M (FK)");
            entity.Property(e => e.idOrder).HasComment("Айди заказа для связи M:M (FK)");

            entity.HasOne(d => d.idItemNavigation).WithMany()
                .HasForeignKey(d => d.idItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_table1_Item1");

            entity.HasOne(d => d.idOrderNavigation).WithMany()
                .HasForeignKey(d => d.idOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_table1_Order1");
        });

        modelBuilder.Entity<ItemCharacteristicValue>(entity =>
        {
            entity.HasKey(e => e.idItemCharacteristicValue).HasName("PRIMARY");
            entity.ToTable("ItemCharacteristicValue", tb => tb.HasComment("Таблица для обеспечения связи N:M (Item <-> ValueCharacteristic)"));

            entity.HasIndex(e => e.idItem, "fk_ItemCharacteristicValue_Item1_idx");

            entity.HasIndex(e => e.idValueCharacteristic, "fk_ItemCharacteristicValue_ValueCharacteristic1_idx");

            entity.Property(e => e.idItemCharacteristicValue)
                .HasComment("Идентификатор");

            entity.Property(e => e.idItem).HasComment("Айди товара для связи M:M (FK)");
            entity.Property(e => e.idValueCharacteristic).HasComment("Айди значения характеристики для связи M:M (FK)");

            entity.HasOne(d => d.idItemNavigation).WithMany()
                .HasForeignKey(d => d.idItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ItemCharacteristicValue_Item1");

            entity.HasOne(d => d.idValueCharacteristicNavigation).WithMany()
                .HasForeignKey(d => d.idValueCharacteristic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ItemCharacteristicValue_ValueCharacteristic1");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.idStatusOrder).HasName("PRIMARY");

            entity.ToTable("StatusOrder", tb => tb.HasComment("Статус заказа"));

            entity.Property(e => e.idStatusOrder).HasComment("Идентификатор статуса заказа");
            entity.Property(e => e.nameStatus)
                .HasMaxLength(20)
                .HasComment("Название статуса заказа");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
