-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: win2012-01    Database: pp67_gestionmateriales
-- ------------------------------------------------------
-- Server version	5.7.19-log

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
-- Dumping data for table `entrada`
--

LOCK TABLES `entrada` WRITE;
/*!40000 ALTER TABLE `entrada` DISABLE KEYS */;
INSERT INTO `entrada` VALUES (1,'2017-11-15 12:28:34',1212,'15',14,2);
/*!40000 ALTER TABLE `entrada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `itemop`
--

LOCK TABLES `itemop` WRITE;
/*!40000 ALTER TABLE `itemop` DISABLE KEYS */;
INSERT INTO `itemop` VALUES (1,2,12,1),(2,2,2,1),(3,1,14,1);
/*!40000 ALTER TABLE `itemop` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `itemot`
--

LOCK TABLES `itemot` WRITE;
/*!40000 ALTER TABLE `itemot` DISABLE KEYS */;
INSERT INTO `itemot` VALUES (1,5,2,2),(2,9,14,3),(3,7,1,3),(4,10,13,3),(5,4,5,3),(6,6,6,3),(7,7,11,3),(8,0,3,3),(9,9,14,4),(10,4,2,4);
/*!40000 ALTER TABLE `itemot` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `material`
--

LOCK TABLES `material` WRITE;
/*!40000 ALTER TABLE `material` DISABLE KEYS */;
INSERT INTO `material` VALUES (1,'1000','Martillo',0,30,1,1,2,'Sin Stock',NULL,1),(2,'100','Taladro',25,8,1,1,2,'Sin Stock','No funciona',1),(3,'1000','Hoja de Lija',0,1000,1,1,1,'Sin Stock',NULL,1),(4,'1001','Lija',0,1000,1,1,1,'Sin Stock',NULL,1),(5,'1000','Papel de Lija',0,1000,1,1,1,'Sin Stock',NULL,1),(6,'1000','Sillas',0,11,1,1,1,'Sin Stock',NULL,1),(7,'1000','Electrodos',0,11,6,1,1,'Sin Stock',NULL,1),(8,'3232','Mesa',0,23,3,1,2,'Sin Stock',NULL,1),(9,'19191','Destornillador',0,22,1,1,2,'Sin Stock',NULL,1),(10,'19191','Pinza',0,22,1,1,2,'Sin Stock',NULL,1),(11,'23232','Soldador',0,22,1,1,2,'Sin Stock',NULL,1),(12,'292','Resistencia',0,23,1,1,1,'Sin Stock',NULL,1),(13,'292','Morsa',0,23,1,1,2,'Sin Stock',NULL,0),(14,'15','Tornillo',1278,100,1,1,1,'Sin Stock',NULL,1);
/*!40000 ALTER TABLE `material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `ordenpedido`
--

LOCK TABLES `ordenpedido` WRITE;
/*!40000 ALTER TABLE `ordenpedido` DISABLE KEYS */;
INSERT INTO `ordenpedido` VALUES (1,4,3,'lol',1,'2017-11-16 00:00:00');
/*!40000 ALTER TABLE `ordenpedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `ordentrabajo`
--

LOCK TABLES `ordentrabajo` WRITE;
/*!40000 ALTER TABLE `ordentrabajo` DISABLE KEYS */;
INSERT INTO `ordentrabajo` VALUES (1,11,'Martillo',1,'2017-03-01 00:00:00',1,1,1,1,1),(2,100,'Mesa',2,'2017-11-11 00:00:00',1,3,1,1,3),(3,1000,'Nuevo',1,'2012-12-11 00:00:00',1,1,1,1,1),(4,2000,'Bodega',1,'2012-12-11 00:00:00',1,1,1,1,1);
/*!40000 ALTER TABLE `ordentrabajo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `personal`
--

LOCK TABLES `personal` WRITE;
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
INSERT INTO `personal` VALUES (1,'Jonathan Velazquez',12345678,123456,1),(2,'Gustavo Colombre',12345678,123456,1),(3,'Gonzalo Suarez',12345678,123456,1),(4,'Roberto Ordoñez',12345678,123456,1);
/*!40000 ALTER TABLE `personal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'Ferreteria','Libertador 123','12','12','SRL','Pepe','9 a 12',1),(2,'Maderera','Libertador 123','11','12','SRL','Pepe','9 a 12',1),(3,'Coto','Libertador 123','13','12','SRL','Pepe','8 a 18',1);
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `salida`
--

LOCK TABLES `salida` WRITE;
/*!40000 ALTER TABLE `salida` DISABLE KEYS */;
/*!40000 ALTER TABLE `salida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tipoentrada`
--

LOCK TABLES `tipoentrada` WRITE;
/*!40000 ALTER TABLE `tipoentrada` DISABLE KEYS */;
INSERT INTO `tipoentrada` VALUES (1,'Sobrante'),(2,'Devolución'),(3,'Orden de Pedido'),(4,'Orden de Trabajo'),(5,'Donación'),(6,'Trabajo Práctico');
/*!40000 ALTER TABLE `tipoentrada` ENABLE KEYS */;
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
INSERT INTO `unidad` VALUES (1,'Cantidad'),(2,'Litros'),(3,'Metros'),(4,'M2'),(5,'M3'),(6,'Kg');
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

-- Dump completed on 2017-11-15 12:31:16
