CREATE DATABASE  IF NOT EXISTS `agoraembuguacu` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `agoraembuguacu`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: agoraembuguacu
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Idade` int NOT NULL DEFAULT '0',
  `Nome` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SobreNome` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IdTipoUsuario` int NOT NULL DEFAULT '0',
  `DataExpiracaoTokenRedefinicaoSenha` datetime(6) DEFAULT NULL,
  `TokenRedefinicaoSenha` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Usuarios_IdTipoUsuario` (`IdTipoUsuario`),
  CONSTRAINT `FK_Usuarios_TipoUsuario_IdTipoUsuario` FOREIGN KEY (`IdTipoUsuario`) REFERENCES `tipousuario` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (3,'usuario1','joao.silva@email.com','$2b$10$Rk5ORdul8TA7tsTw.a6VUuHZx.M9Tzjk2Qa8EIoTiiFIoLoAE2TYy',25,'João','Silva',1,NULL,NULL),(4,'usuario2','maria.santos@email.com','$2b$10$rLpCkDGhlo3QvuOT.ytR8e9awWZoo/0py4X.BW1vKl1CanaLxNbWe',30,'Maria','Santos',2,NULL,NULL),(5,'usuario3','pedro.ferreira@email.com','$2b$10$LuA3OYL7tHe6lBOzJhx/EerDCRPxNS5PcNdmTTdnL3qzL0Q8qGDsq',22,'Pedro','Ferreira',3,NULL,NULL),(6,'usuario4','ana.oliveira@email.com','$2b$10$RlT8GjXHhv8BMG2DlIY.JeuFbZzXZgQFrttuE4zDlbxsN9tJwCL3C',28,'Ana','Oliveira',3,NULL,NULL),(7,'usuario5','luiz.ribeiro@email.com','$2b$10$hPI3PPteX6HgwrRo4GANP.AWLb8m7QZ6Twa2vOWK4h2CtymDXEoi.',35,'Luiz','Ribeiro',1,NULL,NULL),(8,'usuario6','sofia.martins@email.com','$2b$10$geujLqJM/2rnphxoW8FxBelR3Iy8DfsQziazZtRILtxy1Ra8n1DzG',40,'Sofia','Martins',2,NULL,NULL),(9,'usuario7','lucas.pereira@email.com','$2b$10$cGgxcOggJOL1HU71SahEhe2ugXAvNzR.KYnN8q/NUm3UApr74ABWG',29,'Lucas','Pereira',3,NULL,NULL),(10,'usuario8','mariana.rodrigues@email.com','$2b$10$QmgjRP1UY/JVdajN4PFQ0.AkkFBZ/oa0X/IUBAskrclHeqbs99OSG',33,'Mariana','Rodrigues',1,NULL,NULL),(11,'usuario9','paulo.gomes@email.com','$2b$10$rWsVesvLrJsAxjNP9bcpoO1pgAOGAkRucrXK5V2.1ejgLR0WxWNwG',27,'Paulo','Gomes',2,NULL,NULL),(12,'usuario10','camila.fernandes@email.com','$2b$10$4MTnAB7YYylIhtWX701Tqe0F7ytxioz22FCbJWf1DSGbik7DevC3W',38,'Camila','Fernandes',3,NULL,NULL),(13,'usuario11','carlos.almeida@email.com','$2b$10$.iDeI5IYlMjL5y2wMGoGguQSydbelBqTp6eFg165X56Ade6GfNRm.',26,'Carlos','Almeida',1,NULL,NULL),(14,'usuario12','fernanda.lima@email.com','$2b$10$G8UtmZBYYxAoo1I1jLu9HePZ9vj9MAjzSAukhZZ4bW.WEaNtBsqUe',31,'Fernanda','Lima',2,NULL,NULL),(15,'usuario13','rodrigo.barbosa@email.com','$2b$10$JhcwU/BUxgPNOVgoaH4ySueavmHgHlY4L0NdDWuG8.UvFA1wTbLx2',24,'Rodrigo','Barbosa',3,NULL,NULL),(16,'usuario14','larissa.costa@email.com','$2b$10$2Dv1rnUrJGZuYLKXMAtuYOlITI1mcnOeBHSo6iYldsutsQIemiHmq',29,'Larissa','Costa',1,NULL,NULL),(17,'usuario15','gustavo.sousa@email.com','$2b$10$Cu5mYvkpDPSldUIF6Mu2/.wuM3m53tENNRDmO6pBtrwYZR3hGdMdG',33,'Gustavo','Sousa',2,NULL,NULL),(18,'usuario16','isabela.oliveira@email.com','$2b$10$kP0OCAR5mDcadnorgoLNC.rrEalbMXttgqxuR7P4DgjFxodUe4FMy',22,'Isabela','Oliveira',3,NULL,NULL),(19,'usuario17','eduardo.pereira@email.com','$2b$10$7FJx1GJAtfWu0sxBO49pLO08KKP5Q9RVRJO4McumKwEh4RX8fYtW.',27,'Eduardo','Pereira',1,NULL,NULL),(20,'usuario18','vanessa.ferreira@email.com','$2b$10$RQSmzR3FgnJU6jsHiy9ue.Eb0x6RGltIYW8OK/U1H0wRDeswZ4QBi',30,'Vanessa','Ferreira',2,NULL,NULL),(21,'usuario19','marcos.silva@email.com','$2b$10$XhX73fbxTKNjxMnOvkh3VuFfSiddtDsy11bbH7nAgdn3rNDGRK8Py',25,'Marcos','Silva',3,NULL,NULL),(22,'usuario20','ana.lima@email.com','$2b$10$bhisNFO0xn9TgHKWeu6mieM4ruiqzmrsdJe8bg6mogqEQYwNYZUyS',28,'Ana','Lima',1,NULL,NULL);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-05 20:56:05
