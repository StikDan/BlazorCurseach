-- MySQL Workbench Synchronization
-- Generated: 2025-10-27 11:03
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: User

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `Marketplace` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_520_ci ;

CREATE TABLE IF NOT EXISTS `Marketplace`.`Client` (
  `idClient` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор клиента',
  `firstName` VARCHAR(45) NOT NULL COMMENT 'Имя клиента',
  `lastName` VARCHAR(45) NOT NULL COMMENT 'Фамилия клиента',
  `fatherName` VARCHAR(45) NOT NULL COMMENT 'Отчество клиента',
  `phone` VARCHAR(12) NULL DEFAULT NULL COMMENT 'Телефон клиента',
  `email` VARCHAR(50) NOT NULL COMMENT 'Электронная почта клиента',
  `login` VARCHAR(45) NOT NULL COMMENT 'Логин клиента',
  `password` VARCHAR(45) NOT NULL COMMENT 'Пароль клиента',
  PRIMARY KEY (`idClient`),
  UNIQUE INDEX `login_UNIQUE` (`login` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci
COMMENT = 'Клиент веб-приложения (Пользователь)';

CREATE TABLE IF NOT EXISTS `Marketplace`.`Order` (
  `idOrder` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор заказа',
  `dateCreated` DATETIME NOT NULL COMMENT 'Дата создания заказа',
  `descOrder` VARCHAR(400) NULL DEFAULT NULL COMMENT 'Описание заказа',
  `idStatusOrder` INT(11) NOT NULL COMMENT 'Идентификатор статуса заказа (FK)',
  `idClient` INT(11) NOT NULL COMMENT 'Айди клиента (FK)',
  PRIMARY KEY (`idOrder`),
  INDEX `fk_Order_StatusOrder_idx` (`idStatusOrder` ASC) VISIBLE,
  INDEX `fk_Order_Client1_idx` (`idClient` ASC) VISIBLE,
  CONSTRAINT `fk_Order_StatusOrder`
    FOREIGN KEY (`idStatusOrder`)
    REFERENCES `Marketplace`.`StatusOrder` (`idStatusOrder`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Order_Client1`
    FOREIGN KEY (`idClient`)
    REFERENCES `Marketplace`.`Client` (`idClient`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci
COMMENT = 'Заказ';

CREATE TABLE IF NOT EXISTS `Marketplace`.`StatusOrder` (
  `idStatusOrder` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор статуса заказа',
  `nameStatus` VARCHAR(20) NOT NULL COMMENT 'Название статуса заказа',
  PRIMARY KEY (`idStatusOrder`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci
COMMENT = 'Статус заказа';

CREATE TABLE IF NOT EXISTS `Marketplace`.`Item` (
  `idItem` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор товара',
  `nameItem` VARCHAR(70) NOT NULL COMMENT 'Название товара',
  `price` DOUBLE NOT NULL COMMENT 'Цена товара',
  `descItem` VARCHAR(400) NOT NULL COMMENT 'Описание товара',
  `inCart` TINYINT(0) NOT NULL DEFAULT 0 COMMENT 'Флаг, определяющий, в корзине ли товар (по умолчанию false)',
  `countItem` INT(11) NOT NULL COMMENT 'Доступное количество товаров',
  `idCategory` INT(11) NOT NULL COMMENT 'Идентификатор категории товара (FK)',
  PRIMARY KEY (`idItem`),
  INDEX `fk_Item_Category1_idx` (`idCategory` ASC) VISIBLE,
  CONSTRAINT `fk_Item_Category1`
    FOREIGN KEY (`idCategory`)
    REFERENCES `Marketplace`.`Category` (`idCategory`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci
COMMENT = 'Товар';

CREATE TABLE IF NOT EXISTS `Marketplace`.`OrderItemTemp` (
  `idItem` INT(11) NOT NULL COMMENT 'Айди товара для связи M:M (FK)',
  `idOrder` INT(11) NOT NULL COMMENT 'Айди заказа для связи M:M (FK)',
  INDEX `fk_table1_Item1_idx` (`idItem` ASC) VISIBLE,
  INDEX `fk_table1_Order1_idx` (`idOrder` ASC) VISIBLE,
  CONSTRAINT `fk_table1_Item1`
    FOREIGN KEY (`idItem`)
    REFERENCES `Marketplace`.`Item` (`idItem`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_table1_Order1`
    FOREIGN KEY (`idOrder`)
    REFERENCES `Marketplace`.`Order` (`idOrder`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci
COMMENT = 'Таблица для обеспечения связи N:M (Item <-> Order)';

CREATE TABLE IF NOT EXISTS `Marketplace`.`Category` (
  `idCategory` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор категории',
  `nameCategory` VARCHAR(60) NOT NULL COMMENT 'Название категории товаров',
  PRIMARY KEY (`idCategory`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci
COMMENT = 'Категория товара';

CREATE TABLE IF NOT EXISTS `Marketplace`.`CharacteristicItem` (
  `idCharacteristicItem` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор характеристики товара',
  `nameCharacteristicItem` VARCHAR(60) NOT NULL COMMENT 'Название характеристики',
  `idItem` INT(11) NOT NULL COMMENT 'Айди товара (FK)',
  PRIMARY KEY (`idCharacteristicItem`),
  INDEX `fk_CharacteristicCategory_Item1_idx` (`idItem` ASC) VISIBLE,
  CONSTRAINT `fk_CharacteristicCategory_Item1`
    FOREIGN KEY (`idItem`)
    REFERENCES `Marketplace`.`Item` (`idItem`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci
COMMENT = 'Характеристика товара';


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
