-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: pp67_oficinatecnica
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
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES ('1','administrador'),('2','oficinatecnica'),('3','deposito'),('4','compras'),('5','rectoria'),('6','cooperadora');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `userclaims`
--

LOCK TABLES `userclaims` WRITE;
/*!40000 ALTER TABLE `userclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `userclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `userlogins`
--

LOCK TABLES `userlogins` WRITE;
/*!40000 ALTER TABLE `userlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `userlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES ('ab1f2dee-9adf-4d23-a5ca-76a2be7c05a4','1'),('d0c69cce-de8f-4fa2-ba68-8d6b8d64d576','1'),('de8c298d-7128-49e9-8ee1-17af4ef8a834','1'),('b58b703e-1d9f-4963-b507-a7832afb366a','2'),('88feedd7-adc9-46a8-9343-1960f92148c2','3'),('6dce5c32-474d-4e8e-80f3-a9be4ac0fc5b','4'),('ac5f7bf1-3419-4eb0-a333-1f7cb1ad4a58','5'),('26d02a79-a3a4-48f4-9470-768121998bdb','6');
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('26d02a79-a3a4-48f4-9470-768121998bdb','invitado@et12.com',0,'AEarWD+3DhYREc2IJWFScZAfSeJfg52GTCQiigSNZzRpBO4teZSBn7otMJvsEg86kw==','789a823c-696b-4d18-8b0d-2d721753e2cc',NULL,0,0,NULL,1,0,'invitado'),('6dce5c32-474d-4e8e-80f3-a9be4ac0fc5b','usuario@compras.com',0,'AGlswoPRW2HkGUkxQp/mN7K+MyM7Nc6TKP+g/yoBmxJ4K8SMT7FX1i5f/R2Lh0vWQA==','69fa6b05-d486-4571-a87f-e1e3ad9a805f',NULL,0,0,NULL,1,0,'usuariocompras'),('88feedd7-adc9-46a8-9343-1960f92148c2','usuario@deposito.com',0,'AIzOLqMx1KJ2ddXXbEqLdNxBYxmPENkSwSLTUuwARnuhTU8+7wulqs8bWRw8a1sRMg==','33775214-28d6-4482-be59-7e9e34155fe9',NULL,0,0,NULL,1,0,'usuariodeposito'),('ab1f2dee-9adf-4d23-a5ca-76a2be7c05a4','jonathan@et12.com',0,'AM1hwa+3BL1baDLKrtnTL2PtMABkW4d/WeolkM/hwUFU5b45BXcq6mWXxAUR9REJxQ==','e9094f60-c711-41f1-ab8b-8563104fe591',NULL,0,0,NULL,1,0,'jonathan'),('ac5f7bf1-3419-4eb0-a333-1f7cb1ad4a58','usuario@rectoria.com',0,'AKbRMAojgC9lqr4p4EmmIcRLI3PXauOAVYq+wQf6lt3T9O5N1Y/SY2dCdp+SB72u/g==','35ac03c8-d5bc-4a0b-b090-3640fa883cc7',NULL,0,0,NULL,1,0,'usuariorectoria'),('b58b703e-1d9f-4963-b507-a7832afb366a','usuario@ot.com',0,'AHlFQPoR8nOWuWf156XRVrGKvpp8qagHiVJAfe/HG5/fK6PalN9EaVwqZXzbHSYwKw==','094d5e5c-0462-426d-9448-a217bd3b05a9',NULL,0,0,NULL,1,0,'usuarioot'),('d0c69cce-de8f-4fa2-ba68-8d6b8d64d576','admin@et12.com',0,'AEZXYwRANal4eIThSe9VSz34eP3aEr2r267VEMJTt3UQGK+ivBYG2WatrQlumBv3bA==','371fe4e5-5c04-40ab-92bc-cc820d9e3788',NULL,0,0,NULL,1,0,'administrador'),('de8c298d-7128-49e9-8ee1-17af4ef8a834','alumno67@et12.com',0,'AH6AHWHYHd8xPh5tmP9TATW19YGCUYgd+SxtMTrFA+EVoyboYHrb9wxPMXdy7TrI+A==','5123b034-240f-4118-bd17-bd3df3905c78',NULL,0,0,NULL,1,0,'alumno67');
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

-- Dump completed on 2018-04-25 22:59:27
