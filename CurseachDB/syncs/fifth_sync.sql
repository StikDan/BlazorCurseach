-- MySQL Workbench Synchronization
-- Generated: 2026-01-09 14:16
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: User

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

ALTER TABLE `Marketplace`.`Client` 
DROP FOREIGN KEY `fk_Client_UserRole1`;

ALTER TABLE `Marketplace`.`Order` 
DROP FOREIGN KEY `fk_Order_Client1`;

ALTER TABLE `Marketplace`.`Item` 
DROP FOREIGN KEY `fk_Item_Category1`;

ALTER TABLE `Marketplace`.`OrderItemTemp` 
DROP FOREIGN KEY `fk_table1_Item1`,
DROP FOREIGN KEY `fk_table1_Order1`;

ALTER TABLE `Marketplace`.`CharacteristicItem` 
DROP FOREIGN KEY `fk_CharacteristicItem_Category1`;

ALTER TABLE `Marketplace`.`ValueCharacteristic` 
DROP FOREIGN KEY `fk_ValueCharacteristic_CharacteristicItem1`;

ALTER TABLE `Marketplace`.`Item` 
CHANGE COLUMN `inCart` `inCart` TINYINT(0) NOT NULL DEFAULT 0 COMMENT 'Флаг, определяющий, в корзине ли товар (по умолчанию false)' ;

CREATE TABLE IF NOT EXISTS `Marketplace`.`ItemCharacteristicValue` (
  `idItem` INT(11) NOT NULL COMMENT 'Айди товара для связи M:M (FK)',
  `idValueCharacteristic` INT(11) NOT NULL COMMENT 'Айди значения характеристики для связи M:M (FK)',
  PRIMARY KEY (`idItem`, `idValueCharacteristic`),
  INDEX `fk_Item_has_ValueCharacteristic_ValueCharacteristic1_idx` (`idValueCharacteristic` ASC) VISIBLE,
  INDEX `fk_Item_has_ValueCharacteristic_Item1_idx` (`idItem` ASC) VISIBLE,
  CONSTRAINT `fk_Item_has_ValueCharacteristic_Item1`
    FOREIGN KEY (`idItem`)
    REFERENCES `Marketplace`.`Item` (`idItem`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Item_has_ValueCharacteristic_ValueCharacteristic1`
    FOREIGN KEY (`idValueCharacteristic`)
    REFERENCES `Marketplace`.`ValueCharacteristic` (`idValueCharacteristic`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci
COMMENT = 'Таблица для обеспечения связи N:M (Item <-> ValueCharacteristic)\n Каждый товар имеет одно значение для каждой характеристики своей категории';

ALTER TABLE `Marketplace`.`Client` 
ADD CONSTRAINT `fk_Client_UserRole1`
  FOREIGN KEY (`idRole`)
  REFERENCES `Marketplace`.`UserRole` (`idRole`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `Marketplace`.`Order` 
DROP FOREIGN KEY `fk_Order_StatusOrder`;

ALTER TABLE `Marketplace`.`Order` ADD CONSTRAINT `fk_Order_StatusOrder`
  FOREIGN KEY (`idStatusOrder`)
  REFERENCES `Marketplace`.`StatusOrder` (`idStatusOrder`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_Order_Client1`
  FOREIGN KEY (`idClient`)
  REFERENCES `Marketplace`.`Client` (`idClient`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `Marketplace`.`Item` 
ADD CONSTRAINT `fk_Item_Category1`
  FOREIGN KEY (`idCategory`)
  REFERENCES `Marketplace`.`Category` (`idCategory`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `Marketplace`.`OrderItemTemp` 
ADD CONSTRAINT `fk_table1_Item1`
  FOREIGN KEY (`idItem`)
  REFERENCES `Marketplace`.`Item` (`idItem`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_table1_Order1`
  FOREIGN KEY (`idOrder`)
  REFERENCES `Marketplace`.`Order` (`idOrder`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `Marketplace`.`CharacteristicItem` 
ADD CONSTRAINT `fk_CharacteristicItem_Category1`
  FOREIGN KEY (`idCategory`)
  REFERENCES `Marketplace`.`Category` (`idCategory`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `Marketplace`.`ValueCharacteristic` 
ADD CONSTRAINT `fk_ValueCharacteristic_CharacteristicItem1`
  FOREIGN KEY (`idCharacteristicItem`)
  REFERENCES `Marketplace`.`CharacteristicItem` (`idCharacteristicItem`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
