CREATE DATABASE  IF NOT EXISTS `ot_usuarios` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `ot_usuarios`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: ot_usuarios
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `Id` varchar(128) NOT NULL,
  `Name` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES ('1','administrador'),('2','oficinatecnica'),('3','deposito'),('4','compras'),('5','rectoria');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userclaims`
--

DROP TABLE IF EXISTS `userclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(128) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserId` (`UserId`),
  CONSTRAINT `ApplicationUser_Claims` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userclaims`
--

LOCK TABLES `userclaims` WRITE;
/*!40000 ALTER TABLE `userclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `userclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userlogins`
--

DROP TABLE IF EXISTS `userlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `UserId` varchar(128) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  KEY `ApplicationUser_Logins` (`UserId`),
  CONSTRAINT `ApplicationUser_Logins` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userlogins`
--

LOCK TABLES `userlogins` WRITE;
/*!40000 ALTER TABLE `userlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `userlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IdentityRole_Users` (`RoleId`),
  CONSTRAINT `ApplicationUser_Roles` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `IdentityRole_Users` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES ('d0c69cce-de8f-4fa2-ba68-8d6b8d64d576','1'),('9ba0b844-1c13-479f-b218-e59c61fa7cdf','2'),('aa7d8f63-b347-416f-b162-7db2fdf82cf6','2'),('ab1f2dee-9adf-4d23-a5ca-76a2be7c05a4','2'),('88feedd7-adc9-46a8-9343-1960f92148c2','3'),('6dce5c32-474d-4e8e-80f3-a9be4ac0fc5b','4'),('ac5f7bf1-3419-4eb0-a333-1f7cb1ad4a58','5');
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `Id` varchar(128) NOT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('262829e5-abda-4826-ab2c-a9d228f79bba','carolina@et12.com',0,'AOJnAYhJ7bsJRWGErSM3tn+4asLufGriYMHALe+uKTEp0diDRdj+HDVqKiMqP2yXUg==','33189e6f-866a-4519-a45f-b636fcc61cac',NULL,0,0,NULL,1,0,'carolina'),('6dce5c32-474d-4e8e-80f3-a9be4ac0fc5b','usuario@compras.com',0,'AGlswoPRW2HkGUkxQp/mN7K+MyM7Nc6TKP+g/yoBmxJ4K8SMT7FX1i5f/R2Lh0vWQA==','69fa6b05-d486-4571-a87f-e1e3ad9a805f',NULL,0,0,NULL,1,0,'compras'),('88feedd7-adc9-46a8-9343-1960f92148c2','usuario@deposito.com',0,'AIzOLqMx1KJ2ddXXbEqLdNxBYxmPENkSwSLTUuwARnuhTU8+7wulqs8bWRw8a1sRMg==','33775214-28d6-4482-be59-7e9e34155fe9',NULL,0,0,NULL,1,0,'deposito'),('9ba0b844-1c13-479f-b218-e59c61fa7cdf','oficinatecnica@et12.com',0,'AIP5K1Q1Okn9M8KStNzx0VTOgmI5kOFzKfqst0Ll7XK4vbeJJrM9GKnVk0kO6VvFIw==','07d9945d-bc32-4725-8c7a-7d9c1bf85222',NULL,0,0,NULL,1,0,'oficinatecnica'),('aa7d8f63-b347-416f-b162-7db2fdf82cf6','caroespinola1999@gmail.com',0,'AOdhC79DjeGVtvM3XA7LBIUYNRMzArPuson+HfnpoFCsarJ9uLpSquYyi+pgiisVEQ==','d9a08e9e-5b8b-4070-b68d-95e8effc938a',NULL,0,0,NULL,1,0,'Carolina Espinola'),('ab1f2dee-9adf-4d23-a5ca-76a2be7c05a4','jonathan@et12.com',0,'AM1hwa+3BL1baDLKrtnTL2PtMABkW4d/WeolkM/hwUFU5b45BXcq6mWXxAUR9REJxQ==','e9094f60-c711-41f1-ab8b-8563104fe591',NULL,0,0,NULL,1,0,'jonathan'),('ac5f7bf1-3419-4eb0-a333-1f7cb1ad4a58','usuario@rectoria.com',0,'AKbRMAojgC9lqr4p4EmmIcRLI3PXauOAVYq+wQf6lt3T9O5N1Y/SY2dCdp+SB72u/g==','35ac03c8-d5bc-4a0b-b090-3640fa883cc7',NULL,0,0,NULL,1,0,'rectoria'),('d0c69cce-de8f-4fa2-ba68-8d6b8d64d576','admin@et12.com',0,'AEZXYwRANal4eIThSe9VSz34eP3aEr2r267VEMJTt3UQGK+ivBYG2WatrQlumBv3bA==','371fe4e5-5c04-40ab-92bc-cc820d9e3788',NULL,0,0,NULL,1,0,'administrador');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-11-02  8:15:33
