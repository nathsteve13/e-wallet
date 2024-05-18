-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema emoneydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema emoneydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `emoneydb` DEFAULT CHARACTER SET utf8mb4 ;
USE `emoneydb` ;

-- -----------------------------------------------------
-- Table `emoneydb`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `emoneydb`.`users` (
  `user_id` INT(11) NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(50) NOT NULL,
  `name` VARCHAR(255) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `phone_number` VARCHAR(15) NOT NULL,
  `password` VARCHAR(255) NOT NULL,
  `role` ENUM('customer','partner','admin') NOT NULL,
  `kartu_identitas` VARCHAR(225) NOT NULL,
  `gender` ENUM('P','L') NOT NULL,
  `birth_date` DATE NOT NULL,
  `pin` INT(11) NOT NULL,
  `foto_wajah` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE INDEX `username` (`username` ASC),
  UNIQUE INDEX `email` (`email` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 39
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `emoneydb`.`balances`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `emoneydb`.`balances` (
  `user_id` INT(11) NOT NULL,
  `current_balance` DECIMAL(10,2) NULL DEFAULT NULL,
  `last_updated` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  CONSTRAINT `balances_ibfk_1`
    FOREIGN KEY (`user_id`)
    REFERENCES `emoneydb`.`users` (`user_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `emoneydb`.`products`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `emoneydb`.`products` (
  `product_id` INT(11) NOT NULL AUTO_INCREMENT,
  `partner_id` INT(11) NOT NULL,
  `name` VARCHAR(255) NOT NULL,
  `price` FLOAT NOT NULL,
  `description` TEXT NULL DEFAULT NULL,
  `stock` INT(11) NOT NULL,
  PRIMARY KEY (`product_id`),
  INDEX `partner_id` (`partner_id` ASC),
  CONSTRAINT `products_ibfk_1`
    FOREIGN KEY (`partner_id`)
    REFERENCES `emoneydb`.`users` (`user_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `emoneydb`.`transactions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `emoneydb`.`transactions` (
  `transaction_id` INT(11) NOT NULL AUTO_INCREMENT,
  `user_id` INT(11) NOT NULL,
  `recipient_id` INT(11) NULL DEFAULT NULL,
  `amount` DECIMAL(10,2) NOT NULL,
  `transaction_type` ENUM('purchase','transfer','topup') NOT NULL,
  `timestamp` DATETIME NULL DEFAULT NULL,
  `description` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`transaction_id`),
  INDEX `user_id` (`user_id` ASC),
  CONSTRAINT `transactions_ibfk_1`
    FOREIGN KEY (`user_id`)
    REFERENCES `emoneydb`.`users` (`user_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 42
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `emoneydb`.`transactionhistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `emoneydb`.`transactionhistory` (
  `history_id` INT(11) NOT NULL AUTO_INCREMENT,
  `transaction_id` INT(11) NOT NULL,
  `user_id` INT(11) NOT NULL,
  `description` TEXT NULL DEFAULT NULL,
  `timestamp` DATETIME NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`history_id`),
  INDEX `transaction_id` (`transaction_id` ASC),
  INDEX `user_id` (`user_id` ASC),
  CONSTRAINT `transactionhistory_ibfk_1`
    FOREIGN KEY (`transaction_id`)
    REFERENCES `emoneydb`.`transactions` (`transaction_id`),
  CONSTRAINT `transactionhistory_ibfk_2`
    FOREIGN KEY (`user_id`)
    REFERENCES `emoneydb`.`users` (`user_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
