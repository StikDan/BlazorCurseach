-- MySQL Workbench Synchronization
-- Generated: 2026-01-06 15:09
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: User

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

ALTER TABLE `Marketplace`.`Item` 
DROP COLUMN `idCategory`,
ADD COLUMN `idCategory` INT(11) NOT NULL COMMENT 'Айди категории (FK)' AFTER `countItem`,
CHANGE COLUMN `inCart` `inCart` TINYINT(0) NOT NULL DEFAULT 0 COMMENT 'Флаг, определяющий, в корзине ли товар (по умолчанию false)' ,
ADD INDEX `fk_Item_Category1_idx` (`idCategory` ASC) VISIBLE,
DROP INDEX `fk_Item_Category1_idx` ;
, COMMENT = 'Товар' ;

ALTER TABLE `Marketplace`.`OrderItemTemp` 
COLLATE = utf8mb4_unicode_520_ci , COMMENT = 'Таблица для обеспечения связи N:M (Item <-> Order)' ;

ALTER TABLE `Marketplace`.`Category` 
COLLATE = utf8mb4_unicode_520_ci , COMMENT = 'Категория товара' ;

ALTER TABLE `Marketplace`.`Characteristic` 
COLLATE = utf8mb4_unicode_520_ci ,
DROP COLUMN `idCategory`,
ADD COLUMN `idCategory` INT(11) NOT NULL COMMENT 'Айди категории (FK)' AFTER `nameCharacteristicItem`,
CHANGE COLUMN `idCharacteristic` `idCharacteristicItem` INT(11) NOT NULL AUTO_INCREMENT COMMENT 'Идентификатор характеристики товара' ,
CHANGE COLUMN `nameCharacteristic` `nameCharacteristicItem` VARCHAR(60) NOT NULL COMMENT 'Название характеристики' ,
ADD INDEX `fk_CharacteristicItem_Category1_idx` (`idCategory` ASC) VISIBLE,
DROP INDEX `fk_Characteristic_Category1_idx` ;
, COMMENT = 'Характеристика товара' , RENAME TO  `Marketplace`.`CharacteristicItem` ;

CREATE TABLE IF NOT EXISTS `Marketplace`.`ValueCharacteristic` (
  `idValueCharacteristic` INT(11) NOT NULL,
  `selfValue` VARCHAR(45) NOT NULL,
  `idCharacteristicItem` INT(11) NOT NULL,
  PRIMARY KEY (`idValueCharacteristic`),
  INDEX `fk_ValueCharacteristic_CharacteristicItem1_idx` (`idCharacteristicItem` ASC) VISIBLE,
  CONSTRAINT `fk_ValueCharacteristic_CharacteristicItem1`
    FOREIGN KEY (`idCharacteristicItem`)
    REFERENCES `Marketplace`.`CharacteristicItem` (`idCharacteristicItem`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;

ALTER TABLE `Marketplace`.`Client` 
ADD CONSTRAINT `fk_Client_UserRole1`
  FOREIGN KEY (`idRole`)
  REFERENCES `Marketplace`.`UserRole` (`idRole`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `Marketplace`.`Order` 
ADD CONSTRAINT `fk_Order_StatusOrder`
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

ALTER TABLE `Marketplace`.`Characteristic` 
ADD CONSTRAINT `fk_CharacteristicItem_Category1`
  FOREIGN KEY (`idCategory`)
  REFERENCES `Marketplace`.`Category` (`idCategory`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
