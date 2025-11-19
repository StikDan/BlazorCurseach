-- MySQL Workbench Synchronization
-- Generated: 2025-10-25 20:05
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: User

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `Marketplace` DEFAULT CHARACTER SET utf8mb4 ;

CREATE TABLE IF NOT EXISTS `Marketplace`.`Client` (
  `idClient` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор клиента',
  `firstName` VARCHAR(45) NOT NULL COMMENT 'Имя клиента',
  `lastName` VARCHAR(45) NOT NULL COMMENT 'Фамилия клиента',
  `fatherName` VARCHAR(45) NOT NULL COMMENT 'Отчество клиента',
  `phone` VARCHAR(12) NULL DEFAULT NULL,
  `email` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idClient`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;

CREATE TABLE IF NOT EXISTS `Marketplace`.`Order` (
  `idOrder` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор заказа',
  `dateCreated` DATETIME NOT NULL COMMENT 'Дата создания заказа',
  `descOrder` VARCHAR(400) NULL DEFAULT NULL COMMENT 'Описание заказа',
  `idStatusOrder` INT(11) NOT NULL COMMENT 'Идентификатор статуса заказа (FK)',
  `idClient` INT(11) NOT NULL,
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
DEFAULT CHARACTER SET = utf8mb4;

CREATE TABLE IF NOT EXISTS `Marketplace`.`StatusOrder` (
  `idStatusOrder` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор статуса заказа',
  `nameStatus` VARCHAR(20) NOT NULL COMMENT 'Название статуса заказа',
  PRIMARY KEY (`idStatusOrder`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;

CREATE TABLE IF NOT EXISTS `Marketplace`.`Item` (
  `idItem` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор товара',
  `nameItem` VARCHAR(70) NOT NULL COMMENT 'Название товара',
  `price` DOUBLE NOT NULL COMMENT 'Цена товара',
  `descItem` VARCHAR(400) NOT NULL COMMENT 'Описание товара',
  `inCart` TINYINT(0) NOT NULL COMMENT 'Флаг, определяющий, в корзине ли товар (по умолчанию false)',
  `idCategory` INT(11) NOT NULL COMMENT 'Идентификатор категории товара (FK)',
  PRIMARY KEY (`idItem`),
  INDEX `fk_Item_Category1_idx` (`idCategory` ASC) VISIBLE,
  CONSTRAINT `fk_Item_Category1`
    FOREIGN KEY (`idCategory`)
    REFERENCES `Marketplace`.`Category` (`idCategory`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;

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
DEFAULT CHARACTER SET = utf8mb4;

CREATE TABLE IF NOT EXISTS `Marketplace`.`Category` (
  `idCategory` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор категории',
  `nameCategory` VARCHAR(60) NOT NULL COMMENT 'Название категории товаров',
  PRIMARY KEY (`idCategory`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;

CREATE TABLE IF NOT EXISTS `Marketplace`.`Characteristic` (
  `idCharacteristic` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор характеристики товара',
  `nameCharacteristic` VARCHAR(60) NOT NULL COMMENT 'Название характеристики',
  `idCategory` INT(11) NOT NULL COMMENT 'Айди категории товара (FK)',
  PRIMARY KEY (`idCharacteristic`),
  INDEX `fk_Characteristic_Category1_idx` (`idCategory` ASC) VISIBLE,
  CONSTRAINT `fk_Characteristic_Category1`
    FOREIGN KEY (`idCategory`)
    REFERENCES `Marketplace`.`Category` (`idCategory`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;

CREATE TABLE IF NOT EXISTS `Marketplace`.`ValueCharacteristic` (
  `idValueCharacteristic` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор значения/параметра характеристики товара \n(например: Хар-ка = Процессор, Значение = Intel i5  => Процессор:Intel i5)',
  `nameValue` VARCHAR(60) NOT NULL COMMENT 'Название значения характеристики',
  `idCharacteristic` INT(11) NOT NULL COMMENT 'Айди характеристики (FK)',
  PRIMARY KEY (`idValueCharacteristic`),
  INDEX `fk_ValueCharacteristic_Characteristic1_idx` (`idCharacteristic` ASC) VISIBLE,
  CONSTRAINT `fk_ValueCharacteristic_Characteristic1`
    FOREIGN KEY (`idCharacteristic`)
    REFERENCES `Marketplace`.`Characteristic` (`idCharacteristic`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
