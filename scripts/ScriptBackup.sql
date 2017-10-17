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
-- Table structure for table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`,`ContextKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__migrationhistory`
--

LOCK TABLES `__migrationhistory` WRITE;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
INSERT INTO `__migrationhistory` VALUES ('201710010521063_InitialCreate','gestionmateriales.Models.GestionMateriales.OtContext','ã\0\0\0\0\0\0\Ì]\€n\‰∏}êhÙc0\Î∂gˆíˆ.f=;\'\Î±1ˆ,Ú6ê[¥GYµ‘ë\‘;Aæ,˘§¸B®ñHÒR≈ãDIˆn\‡∑$ãáE≤X$ˇ˚\Ôˇú|˜∞IüIQ&yv∫<:8\\.H∂\Œ\„$ª?]Ó™ª/˛∏¸\Ó\€\ﬂˇ\Ó\‰áxÛ∞¯ô}˜™˛é¶\Ã\ \”Âß™\⁄ØV\Â˙\ŸD\Â¡&Yyô\ﬂU\Î|≥ä\‚|ıÚO´££°KäµXúº\ﬂeU≤!˚Ù\ÁYû≠…∂\⁄E\ÈEì¥lü\”7\◊{\‘≈ªhC\ m¥&ß\À{RVTÜMTë\"âRR4i~l^\\\À\≈\Î4â®Ñ\◊$Ω[.¢,À´®˛\‰¯CIÆ´\"\œÓØ∑ÙAî\ﬁ<n	˝\Ó.JK“ñ\Î∏˚‹µàá/\Î\"Æ∫ÑjΩ+´|\„	xÙ™\’\ŸJM\ﬁKÛKÆS™\’®ˆ´«∫\‘{Õû.\ÈÉ\"ä£\ÂB\Õ\Î¯,-\Í\Ô|Ù~–¢ΩXhi^p\nQ¶\’/gª¥\⁄\‰4#;ö*}±∏\⁄›¶\…˙/\‰Ò&ˇÖdß\Ÿ.ME\·©¯ÙùÙÄ>∫*Ú-)™\«˜\‰Æ-RÛB≠\‰\‰+5=O≠\'m\ ~ûUØ^.\Ô®(\—mJ8S=]WyA~$)ha„´®¢E¶}ìΩÆ5!î,\Ô\»˙\œ\Ó\rÖ∏°\Õ\»—å≤éhfq\€‰∂†\–\÷ü3\⁄P®-X..¢áüHv_}¢V\‚´\Â\‚mÚ@bˆ†Ö˝ê%4-MS;·ìòQhò¯7\…6o\Î\Ô„πØ*\ﬁEüì˚}ç*®ùl\ÔI∫ˇ†¸îl\€r¿^~\‰ºy[\‰õ˜y*$d\Ô>\ﬁD\≈=©®\\9Ú¡uæ+\÷¢	•\„ã\ﬂuØπLF\ËVQÃìUgZåßSgã\√˛ù\€\‰t\≈Ú∑9Æ\Ïgtfj\ËYæπ-à!\€oF…ñ\“l˝\À\Îu=\ f`ˆ@IñlÚa@¥<\‘X˚)Ü˛¸LHúÉë\Í\Ê\Õ\Õ\—P0\⁄\È\ƒƒÆócTsL™(MMÙ::<t\ ÿúœß\Ë6I±à\ﬂ\Á\‘VFŸÄN\∆d≈Ω˙\’~£ùê´dúcfŸÑ\œ\0\È:¢¢Úuü¯Jx•	¢∫\Ê\’\«\Œ¿v≤)Ø¥\ŒY}ﬂßov:\»_⁄ì\Z\'™@\È+_6\…,\'˚ê∞µg®l\Ì˚AÅaAFoÓ°ÉP0ˇ±Éêx™¡Éµˇrî^<N\n≤^\Ôg¡É\rº\ÔºhóTÜ\\_éíiERróg¶~túåã\ËyvùØÖ\È\ƒ#ƒ≥<´¢ue*∫#\«,=y^DE2ΩÜ˚é úm%\ÎÉ\ ln+…ä\‰o\"Y\ ﬂÑGßü\√cú§ˆÒ\ÿ8\ y|I)îgfπ∫o4π\ÿ+L.˛~\ÿÿÉf\Ë\—\¬\Õ›¶∫bıx¥Of\‹Òı(\∆:Œía\”·ªÑ⁄É3íïC\›£wÚL$\’E»π\È.œüÚr˙\'C˚cgä∞I`r4`s”Ç…ü,Âì°BàAπóµª|( \ŒM\n©p˝L\≈\‰KâVzºöíó˚ä\ƒI\›]°áÄ87=§\¬˘\”CJ>=ä\‹#_7¨õ\"∫ç˛6,Æ´\“\Ë\Ë8˙\Íy\Œ\√eÖk-\‰ìhºx=õÅ#Ö¬∑É \‹mlÆ≠léB\‡õ]ë\ÂÉ\◊\Î\¬8,˛L\Ó\»u\„°,\—{Rns:a¢)FrúWdsy:\ZDB|d\ﬂu\Œ\‡µ\ÊpÄæÒuÜ:¥ã)}å\»*VäQ`ÒC_©Ö⁄≤K-}åH-VøQjÒC_©˜m\«.o˚\"i\”\0ç26ür?1B\È@\Z∞πªV$ˇNÉ•ú,V&∞#v\√=\0ıZª\—}\”ÒNy•ëN}?àq-\Î\√\Ã\Íj¨π˘\÷®\«LÆI8\ÌN\ \ZMå7è{]ñı\“_]e\ÂÄ«ü\»¯!ã∂`î¶b4-≠\ÎdKkó\nAG¯Kµ/≥7$%Yº^7°\”gQπébΩ•—Ç\ƒ\Œ\"Ò0èN$>Oó%˙Éñ\Â)\Íjå\“3\⁄ji™$´tÚ%\Ÿ:\ŸF©E)J:œ∞¬∫\ÿ<\'ı\Õ≤%Y\Õ7ãÜã¿sRjƒ¶©ìï@3Gˆuë\÷\ ¬ç\Ï\‘\Î€àIà≈ê°é\‘\÷\Á¨\0umì]®\Îd+°\ÓG£§\Ï˙Qhæ\»dëO_Phm\ÈP¨jæ˙∞\–pDòïìpxX ¬ÉQe∏º&2Ü2Z\'ªUR5-êî\–5ñyˇ\Z\n\ÿ\«$4F\Ô˜\Ë\›\Ã\»H\’#ËÉî†éÅ11\—q\'\"õ+∏óEO:ÑÒP\‰∏¿\ fÙbtÂìùc∂äµ\Ê\0h–©Z˙*Atã8\…	˙H\‹\‘abí’Ω2vwÇ∫]ú$}0Åµπo&\’J3\œríUÒÙ÷Ñ\Ï$çl3Ï≠Äfí∑®LËúî)°™üêá\nò\‚(I;\À/€â§ZÇ\ZÒöT\Í÷Ön>©v=ödÑŒ†jh∏Üä!åΩ5<¿ZEacE\râ>‘§\‡å’Ö¿b≠TyD•\·ÉXT,6D\—PêòHº~Mk\‰*í¥Ú®!ôñSA$\ﬁ\ﬁ`(lMJ\≈j:¢ÄA¸ìöÇöÊ©´t7	mTg∑ΩG¯\€§é4ú0\\t±¡iSz◊â\0ÑFH\»%ı—Ç\–X\rz@úÆ\ÓÄﬁ∫\–\Áˇîa#á∑>¥à\\]F«Äìk@ê6pNæ\0eˆW@g6Q¿N\'7A/h~ëhDmˇ![|C£¿\›éÉ\ﬁMÙh\Ê\Ë\À˛\Ía]ôA1ê¡…â\–[ä\◊@¿¡¢\rΩ\0n\Ó◊ï`u)8;\Ïv\ﬂŸã†\–\"\\7¢≠ü\È\n1∫úÇÙ|\0aP\ÊR\«nÇë∫¨~gœÅP\”\ÿ\À\ŸO`\◊\ÓP≠HÅ’†\ﬁ?\¬`%AÑq˙<Z√¢*\‘\≈\‡\Ád¨*»´0Å™\⁄!øEIÄ\«¡\’\Á0X1≤ìA¥¡\‚8™∂v\Ã\›\n¸\›…™9∑´}p≤B¯:πà∂\€$ª¸jü,Æõ”æŒæ∏ˆ?\Ój\”`¨\÷%p\Íóñ\ÁT\ÂEtOî∑4k*\È€§(´7QE5WØúü\≈\Ì≥ŒâÇ\ÃY>≤üDØ,6wd\ﬂ\◊ˇ7i¸è\ﬁu[ÿ∑¥¨õzQx°\0t\ÊZ\ E}\n[îF~J\÷Yû\Ó6ôˆXe$é\’\∆ä8\Ì#wå.BGÑ\Èûz µ\Á\‚H8\Ì3wq\Õ\\V>à\ƒ\—\‘S≠DDıùéz≤R™_[\√\◊¯ß-M\»tv\"ªa\ZÑ\Ìæ\›Ò§\”\‘gé±Ω\"\n{\Êé\"ùå$BI/<Ò\ÿI\Z{\·é\'úì$¢	è›±\‰√íD8˘ç_\À\‰3>®iJ/\›q\Ÿ˘I\"{\Êé¬èCa¯CwqìÑ%>2v\«\‰bx\–,è!-nzß¢l{Po£	/å\Ÿébë\»\’=ˆ0á˚≥U$c∏\‚é\–î\"¢tO›ë§ìOD0ÈÖØ∂ª\”Lt≠w\Ô<\Z$;µDjç\Ï·Ø¥a∑\ÓŸëZ5å\Ó–§±Ñx{f~fπ1c\ﬁgiûÅÛ\\fwÒá±\ÍæãQGì\Zl:wA(&qMò\–YÙ˙ê…ñ\◊<\ÿ(ûq!qR|Ò+µMñuó 5\Â\·¿Rsrú©Ú¢ç\ÃV”Çé	’è±3\’)∫d§6atáz\ƒ\‚5\»÷õ‰∫ÉW°û}≠ôπÇ5\ƒ˛æ6cjs3D|nÜı≥g_ùbX\–H\’i\»¬°:ç©Ò\Íî¬ù\‰\Í4DB´S9\€A™V\Âù?*_iÄ`\—eó¯ ª&⁄áø\“QÇ§¨1Ÿå\‰\·Jg4πÖ\œ I\ÃgD\Ã¡=\Â¿\›˛ı¿\Ïéaê<Ä¸È¥≥:ı L}Áé™\… ¢™\ÔûLõc#578n¬°°a	Ò&\∆\"9\‰\∆G©öêûÕî[(3àÉ¿]Üop:\√¿≠YYWÜl\–rª	G\⁄X,oÏ™ì\‡@1†w\–Rü‰∫¶WGB \Á\‡Í°º∫˙¸\\Ú†\—9ø\ﬂ\Ï\≈0{…ã\Ó ∂ziîÒ,\œ\‚dø£Êº¨è\‡\«x+C\r1Ò&ô%=¿˚+†∏yyÅ\ BB§\÷á\Î]evI}9\Â\Á\∆\Œ\'Ñb”ït≤q_6u(CŸ§∆õª\€)\–\Õ\Ã\·L˛\Ê~lR\„\Îü,õt0òMH¸˛∞>P\∆\n\—\rBa˚\ŒıÜªá%XõØ∏oóm`x“Ω¢áV\¬ÒO<•∏?ÛJ\Œ…ª#úkre∑P∏Gª/∑\‰ù OöUf∏\”dHê™å\‰è\nTñaãâó	]\Î\"®\≈\Õ\Ó\…1Hl_û˘F\‡Ü±]N˙\Ã7m\œ\0ÁåÄ\‚\ÊÑ\Í\Ÿ¿3\–&l∫~ Xœà\ÏXrñ\‘\œÀÑ7ò\‡.¶¡.qé‘õ\nÜçP\ŒJ\∆\›\⁄∫\Õu\ÓI\r√ñ´\…\È\·jr<Ùñq\“±·¥ì\‡|]lı\Ï\n8;Nm\‰4ûA\Ì≈âén∫	\ÀDi\ﬁp&Jp!ôl∫\»Dq,&˚ü\›tñâ¬ô¥\√8\ÿÖdü¥≥\—}\ËØ/®4@\Ë\ÕÆIõ9üÀå ∞ìK\€%™~¬óß\⁄\'¸7\ﬂ%\⁄\Ó–î∂é\ÓuUo\›\Î®lwã™[6õOñãz\Ì!â\Î\Ìöè\◊O\Í˜˚\œ“ÑdU˜\≈Eî%wîπ\ÕI\”ÀØæY.^ßIT6\€x\€Õ®\«\ÍyYNªSè^’ªSIºY©\…˝˜∏\÷(eK˝\0op\ÌzX6:±≥ó-˘\ËÉZ\√\÷#±á\‹WS\Ãj_\≈UA\÷\…˛<Ò\Â\·\‡\Î6˜Ç˚b¥ª¯\ZÑ\ÏsTP9\ÌÇ.OTqz(»¶ù\€vû\≈\‰\·t˘\œ}≤\„\≈˘_Öâ\ÂãEm+ä\„\≈\·\‚_˛óå(õL˚+\»\‡B+\nÑTø\r\ÿ˘(|\ÿ¡\È⁄îp˜ÆΩ-Åı∫1çCZ˘*2ıTiWj\ZJõQ˚\√ªP˚É\\I{Oá5-iªi(∂\’\‘ƒà>ó|µ;OM∞áá\ÊF´\√\ÍWx\›\Êy:†\Z§p?´Ç∏[$K•\¬˜è˙XLjàÑ\⁄“ÉüTJÚ¨˜º\Á\÷˘Üd<t\≈\·ädêH°\r∏É©˝\“\ﬂ\‘\n{y\›¨[á≥\ﬂ\ﬁk\0}\Èè\Ÿmˆ\rã+\Ì˚£á\Ïˆˇ:WüìUdªÅ√™£ó±un™P\\åk;E\Œ\Áuh§,\Âopæ\∆T˘p\0bHw\∆\Âxv\¬:\ƒ\›\n|1âkØÇ:\Ï:H/3Ù)_˚svøß∏?]•≠\ƒ˝a\∆5bÜ´[fº•~.íX˚\ﬂ{\Á{i4\‘\Ôsi\—:∫\Ëue{orb.üî˙*òR\—M†Û]&>éR¡˚\√˚ò`\‰\Ê>P\ \›\·H˚yjC]|≠kŒ´∑GeMÄ∫\Ô⁄Ü}ã˛Æ^•\›kÑ2\¬@æVªèt•\⁄}ê∞@øë:å2d˙Ä-ã˚\…£Ú\„\…©ûû;1ÒS“∞âoqge#¿\“Ù´?\0b\–rú1(\ŒO4\‘DÉ.€öÙˆ\ÊáöR>pó4\ﬂ}\Ãs^¿¨åˆ\'ºpy\ ñÒÅ|≥|Z7*k+æ˜˜\Ác 6 eD\Î]Ò\‚Éëµ\«Y∏\·zŸ¥WUZh!{\‡Ω\Ól~6=`T\œ\—q∑˜td@|›ÇïP⁄ûów\ŒJ∏p(La\»cê\\ô∑\◊p∫úrB˜∏/|ˆ\Ó\√rÏ¶Øˇ~ºN\ƒsøıîÑ±\\\‡.˚ÿΩnVüù\Ë9û\Ó\À\„Q\¬akÙ4Ä∂¸ö¨4a∫i~\Ê\Èá˘|P\œ5ï\—&!^õõ\'`âÒRæ\'6•ï]W\Ó\⁄?ßÒ*z≤ùû£\„>\Ê	HdΩ\”π\Õ˘:wã±ôöñ\”>}óç\∆\"à\ÁÆÊ©âÇ\ﬁ8\“ßÛûÒl«õ•\Ó[êß¶\nz\√\Âˇ©2U\‹˜OMh±C\Ëä\À\Õ∑yÚlËÅù†\Íºz3.1¨˚xÉÛA\Ÿ\Î\⁄ °_%™VfªˇYû-±\€Y°YK≥≥ıt\ﬂ÷ïﬁ¨\'a!Y*|7@\”ÖS\ÂÄ–ÄD5¡Å≠e!ºÉÚ¿˜Z®ô0è†ñ{¡#!\‚Z∏\—\Â\ÔétÑ\ƒ«Çz\’dﬂåñãr\ƒêì1BTÕçM˛µ|¯Ån@H\ƒ$Tú±Ú!_H9\\ô+EûiYIo°¨L!v`V\‹z\¬yÒ\◊hfXlñöõ!h˘≥äÄê∏≠~\Z\Îß\◊L{T\'\‡J;x˚µ∂\r\‹}m^´F¶ˆº∏›Åù<BB4H\’˚ío`π\‘TPt¡^VD6≠˝ıTSè\‚já!\Îe5.™S\Ÿƒã\Á\Ê+bg∞\—\"bÉ`pº/V%>ù¶à»Å±\ﬁZ.1Év\—-+\”X;±\‘PhÙñ/uqBı¶OWD»ß\”\Íz«ù\ÔJ\≈\‚\Œ·©¨∞vö£^\\£9êYí{kÒ\Ï¿\·EO*‘ãiır\ZÊàÇ\ÿ7\‹EñN…≥îu\⁄≤ÕΩ\‘6T\“\·l†Æ®Á¨Ävi):v3å\‚\\M\‚Ø∏\⁄\ŸW¸\›…™v∑\ËOÌå´ì\’˚]Voh~Ω!er\ﬂA\‘gwed-˘¯7\Á\Ÿ]Œº!äD\Ïu0©®ÖÆ¢\◊Eï\‹EÎäæ^ì≤L≤˚\Â\‚\Á(\›’ñ}sK\‚Û\ÏrWmw-2\Ÿ‹¶è¢2jwä)ˇìï&Û\…\Â∂˛UÜ(\¬\œ˚QSE.≥\ÔwI\Zsπ\ﬂQ∂D\ÌßiÉÇÎ∫¨\Í\‡\‡˚GéÙ.\œÅZıq˜\“\r\ŸlS\nV^f\◊\—g\“G∂%˘â\‹G\Î«´ˆ§2\ƒ^≤\⁄O\ﬁ$\—}m\ £KOR«õáoˇp\‚°!,\‘\0\0','6.1.3-40302');
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entrada`
--

DROP TABLE IF EXISTS `entrada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `entrada` (
  `idEntrada` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL,
  `cantidad` int(11) NOT NULL,
  `codigo` varchar(15) NOT NULL,
  `idMaterial` int(11) NOT NULL,
  `TipoEntrada_Id` int(11) NOT NULL,
  `TipoEntrada_idTipoEntrada` int(11) DEFAULT NULL,
  PRIMARY KEY (`idEntrada`),
  UNIQUE KEY `idEntrada` (`idEntrada`),
  KEY `idMaterial` (`idMaterial`),
  KEY `TipoEntrada_idTipoEntrada` (`TipoEntrada_idTipoEntrada`),
  CONSTRAINT `Entrada_TipoEntrada` FOREIGN KEY (`TipoEntrada_idTipoEntrada`) REFERENCES `tipoentrada` (`idTipoEntrada`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Material_Entrada` FOREIGN KEY (`idMaterial`) REFERENCES `material` (`idMaterial`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entrada`
--

LOCK TABLES `entrada` WRITE;
/*!40000 ALTER TABLE `entrada` DISABLE KEYS */;
/*!40000 ALTER TABLE `entrada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemot`
--

DROP TABLE IF EXISTS `itemot`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemot` (
  `idItemOT` int(11) NOT NULL AUTO_INCREMENT,
  `cantidad` int(11) NOT NULL,
  `material_idMaterial` int(11) NOT NULL,
  `OrdenTrabajo_idOrdenTrabajo` int(11) DEFAULT NULL,
  PRIMARY KEY (`idItemOT`),
  UNIQUE KEY `idItemOT` (`idItemOT`),
  KEY `material_idMaterial` (`material_idMaterial`),
  KEY `OrdenTrabajo_idOrdenTrabajo` (`OrdenTrabajo_idOrdenTrabajo`),
  CONSTRAINT `ItemOT_material` FOREIGN KEY (`material_idMaterial`) REFERENCES `material` (`idMaterial`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `OrdenTrabajo_ItemOT` FOREIGN KEY (`OrdenTrabajo_idOrdenTrabajo`) REFERENCES `ordentrabajo` (`idOrdenTrabajo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemot`
--

LOCK TABLES `itemot` WRITE;
/*!40000 ALTER TABLE `itemot` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemot` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `material`
--

DROP TABLE IF EXISTS `material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `material` (
  `idMaterial` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(15) NOT NULL,
  `nombre` varchar(75) NOT NULL,
  `stockActual` int(11) NOT NULL,
  `stockMinimo` int(11) NOT NULL,
  `Unidad_Id` int(11) NOT NULL,
  `Proveedor_Id` int(11) NOT NULL,
  `TipoMaterial_Id` int(11) NOT NULL,
  `estado` varchar(12) NOT NULL,
  `detalle` varchar(100) DEFAULT NULL,
  `habilitado` tinyint(1) NOT NULL,
  `Proveedor_idProveedor` int(11) DEFAULT NULL,
  `TipoMaterial_idTipoMaterial` int(11) DEFAULT NULL,
  `Unidad_idUnidad` int(11) DEFAULT NULL,
  PRIMARY KEY (`idMaterial`),
  UNIQUE KEY `idMaterial` (`idMaterial`),
  KEY `Proveedor_idProveedor` (`Proveedor_idProveedor`),
  KEY `TipoMaterial_idTipoMaterial` (`TipoMaterial_idTipoMaterial`),
  KEY `Unidad_idUnidad` (`Unidad_idUnidad`),
  CONSTRAINT `Material_Proveedor` FOREIGN KEY (`Proveedor_idProveedor`) REFERENCES `proveedor` (`idProveedor`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Material_TipoMaterial` FOREIGN KEY (`TipoMaterial_idTipoMaterial`) REFERENCES `tipomaterial` (`idTipoMaterial`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Material_Unidad` FOREIGN KEY (`Unidad_idUnidad`) REFERENCES `unidad` (`idUnidad`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `material`
--

LOCK TABLES `material` WRITE;
/*!40000 ALTER TABLE `material` DISABLE KEYS */;
INSERT INTO `material` VALUES (1,'15','Tornillo',0,100,3,1,1,'Sin Stock',NULL,1,1,1,3),(2,'100','Taladro',0,8,3,2,2,'Sin Stock','No funciona',1,1,1,3),(3,'1000','Lima',0,1000,3,1,1,'Sin Stock',NULL,1,1,1,3),(4,'1001','Lima',0,1000,3,1,1,'Sin Stock',NULL,1,1,1,1),(5,'1000','Lima',0,1000,3,1,1,'Sin Stock',NULL,0,1,1,3),(6,'1000','Sillas',0,11,1,1,1,'Sin Stock',NULL,1,1,1,3),(7,'1000','jose',0,11,2,1,1,'Sin Stock',NULL,0,1,1,2),(8,'3232','Mesa',0,23,3,1,1,'Sin Stock',NULL,1,1,1,1),(9,'19191','Destornillador',0,22,1,1,1,'Sin Stock',NULL,1,1,1,1),(10,'19191','kdaksdkjal',0,22,1,1,1,'Sin Stock',NULL,1,1,1,1),(11,'23232','dasda',0,22,1,1,1,'Sin Stock',NULL,0,1,1,1),(12,'292','Morsa',0,23,3,1,1,'Sin Stock',NULL,1,1,1,3),(13,'292','Morsa',0,23,3,1,1,'Sin Stock',NULL,0,1,1,3);
/*!40000 ALTER TABLE `material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ordenpedido`
--

DROP TABLE IF EXISTS `ordenpedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ordenpedido` (
  `idOrdenPedido` int(11) NOT NULL AUTO_INCREMENT,
  `nroOrdenPedido` int(11) NOT NULL,
  `nroOrdenTrabajo` int(11) NOT NULL,
  `destino` varchar(150) NOT NULL,
  `habilitado` tinyint(1) NOT NULL,
  PRIMARY KEY (`idOrdenPedido`),
  UNIQUE KEY `idOrdenPedido` (`idOrdenPedido`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordenpedido`
--

LOCK TABLES `ordenpedido` WRITE;
/*!40000 ALTER TABLE `ordenpedido` DISABLE KEYS */;
/*!40000 ALTER TABLE `ordenpedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ordentrabajo`
--

DROP TABLE IF EXISTS `ordentrabajo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ordentrabajo` (
  `idOrdenTrabajo` int(11) NOT NULL AUTO_INCREMENT,
  `nroOrdenTrabajo` int(11) NOT NULL,
  `nombreTrabajo` varchar(70) NOT NULL,
  `Turno_Id` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `JefeSeccion_Id` int(11) NOT NULL,
  `Responsable_Id` int(11) NOT NULL,
  `JefeSeccion_idPersonal` int(11) DEFAULT NULL,
  `Responsable_idPersonal` int(11) DEFAULT NULL,
  `Turno_idTurno` int(11) DEFAULT NULL,
  PRIMARY KEY (`idOrdenTrabajo`),
  UNIQUE KEY `idOrdenTrabajo` (`idOrdenTrabajo`),
  KEY `JefeSeccion_idPersonal` (`JefeSeccion_idPersonal`),
  KEY `Responsable_idPersonal` (`Responsable_idPersonal`),
  KEY `Turno_idTurno` (`Turno_idTurno`),
  CONSTRAINT `OrdenTrabajo_JefeSeccion` FOREIGN KEY (`JefeSeccion_idPersonal`) REFERENCES `personal` (`idPersonal`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `OrdenTrabajo_Responsable` FOREIGN KEY (`Responsable_idPersonal`) REFERENCES `personal` (`idPersonal`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `OrdenTrabajo_Turno` FOREIGN KEY (`Turno_idTurno`) REFERENCES `turno` (`idTurno`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordentrabajo`
--

LOCK TABLES `ordentrabajo` WRITE;
/*!40000 ALTER TABLE `ordentrabajo` DISABLE KEYS */;
INSERT INTO `ordentrabajo` VALUES (1,100,'Banco',1,'2017-10-01 00:00:00',2,1,2,1,1),(2,101,'Martillo',2,'2017-12-01 00:00:00',2,3,2,3,2),(3,1001,'Bodega',3,'2017-10-02 00:00:00',2,2,2,2,3);
/*!40000 ALTER TABLE `ordentrabajo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personal`
--

DROP TABLE IF EXISTS `personal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personal` (
  `idPersonal` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(60) NOT NULL,
  `dni` int(11) NOT NULL,
  `fichaCensal` int(11) NOT NULL,
  `habilitado` tinyint(1) NOT NULL,
  PRIMARY KEY (`idPersonal`),
  UNIQUE KEY `idPersonal` (`idPersonal`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personal`
--

LOCK TABLES `personal` WRITE;
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
INSERT INTO `personal` VALUES (1,'Gustavo Colombre',41353628,123456,1),(2,'Gonzalo Suarez',41235235,456780,1),(3,'Roberto Ordo√±ez',42654987,123789,1),(4,'Artie',23122312,100200,1),(5,'nuevowwwrr',34833834,292293,0),(6,'Jose',23232332,233223,1),(7,'Franco',23232323,232323,1),(8,'Martin',23232323,232323,1),(9,'Pedro',23232323,222222,1),(10,'i want i that way',10191818,101010,0),(11,'Claudio',23232323,232323,1),(12,'Marcos',27272727,222233,1),(13,'Jonathan Velazquez',19122921,192382,1);
/*!40000 ALTER TABLE `personal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proveedor` (
  `idProveedor` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `cuit` varchar(20) NOT NULL,
  `telefono` varchar(20) NOT NULL,
  `razonSocial` varchar(15) NOT NULL,
  `nombreContacto` varchar(45) DEFAULT NULL,
  `horario` varchar(20) NOT NULL,
  `habilitado` tinyint(1) NOT NULL,
  PRIMARY KEY (`idProveedor`),
  UNIQUE KEY `idProveedor` (`idProveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'Ferreteria','ads','11','11','SA','Pepe','10 a 15',1),(2,'Bosch','asd','10','10','SRL','Jose','8 a 16',1),(3,'Maderera','asd','10','10','SRL','Jose','8 a 16',1),(4,'pepe','ancjancjs','292922929','2929292','SRL','dsdajdask','29292',1),(5,'pepesssss','ancjancjs','292922929','2929292','SRL','dsdajdask','29292',1),(6,'dsdasdas','dasdasd','31232','323232','sda','dasdasda','dasas',1);
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salida`
--

DROP TABLE IF EXISTS `salida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salida` (
  `idSalida` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL,
  `cantidad` int(11) NOT NULL,
  `Material_idMaterial` int(11) DEFAULT NULL,
  `Personal_idPersonal` int(11) DEFAULT NULL,
  PRIMARY KEY (`idSalida`),
  UNIQUE KEY `idSalida` (`idSalida`),
  KEY `Material_idMaterial` (`Material_idMaterial`),
  KEY `Personal_idPersonal` (`Personal_idPersonal`),
  CONSTRAINT `Salida_Material` FOREIGN KEY (`Material_idMaterial`) REFERENCES `material` (`idMaterial`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Salida_Personal` FOREIGN KEY (`Personal_idPersonal`) REFERENCES `personal` (`idPersonal`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salida`
--

LOCK TABLES `salida` WRITE;
/*!40000 ALTER TABLE `salida` DISABLE KEYS */;
/*!40000 ALTER TABLE `salida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoentrada`
--

DROP TABLE IF EXISTS `tipoentrada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipoentrada` (
  `idTipoEntrada` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(35) NOT NULL,
  PRIMARY KEY (`idTipoEntrada`),
  UNIQUE KEY `idTipoEntrada` (`idTipoEntrada`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoentrada`
--

LOCK TABLES `tipoentrada` WRITE;
/*!40000 ALTER TABLE `tipoentrada` DISABLE KEYS */;
INSERT INTO `tipoentrada` VALUES (1,'Orden de Trabajo de Aplicaci√≥n'),(2,'Orden de Pedido'),(3,'Donaci√≥n'),(4,'Trabajo Pr√°ctico'),(5,'Sobrante');
/*!40000 ALTER TABLE `tipoentrada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipomaterial`
--

DROP TABLE IF EXISTS `tipomaterial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipomaterial` (
  `idTipoMaterial` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  PRIMARY KEY (`idTipoMaterial`),
  UNIQUE KEY `idTipoMaterial` (`idTipoMaterial`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipomaterial`
--

LOCK TABLES `tipomaterial` WRITE;
/*!40000 ALTER TABLE `tipomaterial` DISABLE KEYS */;
INSERT INTO `tipomaterial` VALUES (1,'Material'),(2,'Herramienta');
/*!40000 ALTER TABLE `tipomaterial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turno`
--

DROP TABLE IF EXISTS `turno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `turno` (
  `idTurno` int(11) NOT NULL AUTO_INCREMENT,
  `nombreTurno` varchar(7) NOT NULL,
  PRIMARY KEY (`idTurno`),
  UNIQUE KEY `idTurno` (`idTurno`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turno`
--

LOCK TABLES `turno` WRITE;
/*!40000 ALTER TABLE `turno` DISABLE KEYS */;
INSERT INTO `turno` VALUES (1,'Ma√±ana'),(2,'Tarde'),(3,'Noche');
/*!40000 ALTER TABLE `turno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidad`
--

DROP TABLE IF EXISTS `unidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidad` (
  `idUnidad` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(15) NOT NULL,
  PRIMARY KEY (`idUnidad`),
  UNIQUE KEY `idUnidad` (`idUnidad`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

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

-- Dump completed on 2017-10-17  9:53:14
