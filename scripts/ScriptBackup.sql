-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: pp67_gestionmateriales
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
-- Dumping data for table `material`
--

LOCK TABLES `material` WRITE;
/*!40000 ALTER TABLE `material` DISABLE KEYS */;
INSERT INTO `material` VALUES (1,'15','Tornillo',0,100,3,1,1,'Sin Stock',NULL,1,1,1,3),(2,'100','Taladro',0,8,3,2,2,'Sin Stock','No funciona',1,1,1,3),(3,'1000','Lima',0,1000,3,1,1,'Sin Stock',NULL,1,1,1,3),(4,'1001','Lima',0,1000,3,1,1,'Sin Stock',NULL,1,1,1,1),(5,'1000','Lima',0,1000,3,1,1,'Sin Stock',NULL,0,1,1,3),(6,'1000','Sillas',0,11,1,1,1,'Sin Stock',NULL,1,1,1,3),(7,'1000','jose',0,11,2,1,1,'Sin Stock',NULL,0,1,1,2),(8,'3232','Mesa',0,23,3,1,1,'Sin Stock',NULL,1,1,1,1),(9,'19191','Destornillador',0,22,1,1,1,'Sin Stock',NULL,1,1,1,1),(10,'19191','kdaksdkjal',0,22,1,1,1,'Sin Stock',NULL,1,1,1,1),(11,'23232','dasda',0,22,1,1,1,'Sin Stock',NULL,0,1,1,1),(12,'292','Morsa',0,23,3,1,1,'Sin Stock',NULL,1,1,1,3),(13,'292','Morsa',0,23,3,1,1,'Sin Stock',NULL,0,1,1,3);
/*!40000 ALTER TABLE `material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `personal`
--

LOCK TABLES `personal` WRITE;
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
INSERT INTO `personal` VALUES (1,'Gustavo Colombre',41353628,123456,1),(2,'Gonzalo Suarez',41235235,456780,1),(3,'Roberto Ordoñez',42654987,123789,1),(4,'Artie',23122312,100200,1),(5,'nuevowwwrr',34833834,292293,0),(6,'Jose',23232332,233223,1),(7,'Franco',23232323,232323,1),(8,'Martin',23232323,232323,1),(9,'Pedro',23232323,222222,1),(10,'i want i that way',10191818,101010,0),(11,'Claudio',23232323,232323,1),(12,'Marcos',27272727,222233,1),(13,'Jonathan Velazquez',19122921,192382,1);
/*!40000 ALTER TABLE `personal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'Ferreteria','ads','11','11','SA','Pepe','10 a 15',1),(2,'Bosch','asd','10','10','SRL','Jose','8 a 16',1),(3,'Maderera','asd','10','10','SRL','Jose','8 a 16',1),(4,'pepe','ancjancjs','292922929','2929292','SRL','dsdajdask','29292',1),(5,'pepesssss','ancjancjs','292922929','2929292','SRL','dsdajdask','29292',1),(6,'dsdasdas','dasdasd','31232','323232','sda','dasdasda','dasas',1);
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tipomaterial`
--

LOCK TABLES `tipomaterial` WRITE;
/*!40000 ALTER TABLE `tipomaterial` DISABLE KEYS */;
INSERT INTO `tipomaterial` VALUES (1,'Material'),(2,'Herramienta');
/*!40000 ALTER TABLE `tipomaterial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `turno`
--

LOCK TABLES `turno` WRITE;
/*!40000 ALTER TABLE `turno` DISABLE KEYS */;
INSERT INTO `turno` VALUES (1,'Mañana'),(2,'Tarde'),(3,'Noche');
/*!40000 ALTER TABLE `turno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `unidad`
--

LOCK TABLES `unidad` WRITE;
/*!40000 ALTER TABLE `unidad` DISABLE KEYS */;
INSERT INTO `unidad` VALUES (1,'Metros'),(2,'Litros'),(3,'Cantidad'),(4,'Mt2'),(5,'Mt3');
/*!40000 ALTER TABLE `unidad` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-10-17  9:37:14
