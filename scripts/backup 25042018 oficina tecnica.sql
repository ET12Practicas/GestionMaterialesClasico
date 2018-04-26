-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: pp67_gestionmateriales_test
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
-- Dumping data for table `entrada`
--

LOCK TABLES `entrada` WRITE;
/*!40000 ALTER TABLE `entrada` DISABLE KEYS */;
/*!40000 ALTER TABLE `entrada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `itemop`
--

LOCK TABLES `itemop` WRITE;
/*!40000 ALTER TABLE `itemop` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemop` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `itemot`
--

LOCK TABLES `itemot` WRITE;
/*!40000 ALTER TABLE `itemot` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemot` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `material`
--

LOCK TABLES `material` WRITE;
/*!40000 ALTER TABLE `material` DISABLE KEYS */;
/*!40000 ALTER TABLE `material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `ordenpedido`
--

LOCK TABLES `ordenpedido` WRITE;
/*!40000 ALTER TABLE `ordenpedido` DISABLE KEYS */;
/*!40000 ALTER TABLE `ordenpedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `ordentrabajoaplicacion`
--

LOCK TABLES `ordentrabajoaplicacion` WRITE;
/*!40000 ALTER TABLE `ordentrabajoaplicacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `ordentrabajoaplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `personal`
--

LOCK TABLES `personal` WRITE;
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
INSERT INTO `personal` VALUES (1,'dasdasss',12121212,121122,1,'administrador','2018-04-25 10:07:07','::1','administrador','2018-04-25 22:13:50','::1');
/*!40000 ALTER TABLE `personal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'AJUSTE','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(2,'Aceros Sud SA','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(3,'Arlex','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(4,'Bulonera Guemes','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(5,'Casa ANIBAL','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(6,'Chillemi Hnos. S.R.L.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(7,'D\'ADAMO','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(8,'DAI ICHI Circuitos S.A.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(9,'DATAYCOM','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(10,'DONACION','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(11,'DONACION AA','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(12,'DONACION El Abuelo','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(13,'De Dos Ferreteria','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(14,'Desconocido','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(15,'DiAnfer','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(16,'Distribuidora AP','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(17,'Distribuidora Barbiero S.R.L','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(18,'E. El Universo de Scharnopolsky y Etlis','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(19,'EXIMETAL S.A.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(20,'El REY del cable','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(21,'El emporio del bulon S.R.L.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(22,'Electricidad Alsina S.A.','Av Belgrano 727    Avellaneda','','4201-8162','Ventas@electricidadalsina.com','','',' prov Bs As','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(23,'Electricidad Autopista','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(24,'Electricidad Chiclana','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(25,'Electrotecnia Delta S.R.L.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(26,'Ernesto A. Rossi y Cia S.A.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(27,'Existencia','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(28,'Faena S.R.L.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(29,'Ferreteria Industrial FIC','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(30,'General Ramos','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(31,'Herpaco','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(32,'Herramientas Libertador','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(33,'Hierros La Tacada S.A.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(34,'Hiperplasticos Colombraro','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(35,'IGNIFUGOS BUENOS AIRES','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(36,'Jumbo Retail','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(37,'LA INDUSTRIAL','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(38,'Lamarina','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(39,'Libreria Libertador','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(40,'MARTCOMP Distribuciones','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(41,'Maderas Gustavo','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(42,'Maderprov','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(43,'Mi PC Informatica','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(44,'Microelectronica Componentes S.R.L.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(45,'NIDECA S:R:L','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(46,'Nafran','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(47,'OESTE AISLANTE','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(48,'Perfimet','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(49,'Pinturerias Del Centro','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(50,'Pinturerias Yanina','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(51,'Rex Pinturerias','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(52,'Sacheco','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(53,'Sanitarios Centro','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(54,'Sologoma S.R.L.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(55,'TECOPIA','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(56,'TITAN','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(57,'Teylem S.A.','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00',''),(58,'Valot','','','','','','','','',1,'','2018-04-25 00:00:00','','','2018-04-25 00:00:00','');
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
INSERT INTO `tipoentrada` VALUES (1,'Sobrante',1),(2,'Devolución',1),(3,'Orden de Pedido',100),(4,'Orden de Trabajo de Aplicación',100),(5,'Orden de Compra',0),(6,'Trabajo Práctico',1),(7,'Donación',0),(8,'Orden de Trabajo',0);
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
-- Dumping data for table `tiposalida`
--

LOCK TABLES `tiposalida` WRITE;
/*!40000 ALTER TABLE `tiposalida` DISABLE KEYS */;
/*!40000 ALTER TABLE `tiposalida` ENABLE KEYS */;
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

-- Dump completed on 2018-04-25 22:53:21
