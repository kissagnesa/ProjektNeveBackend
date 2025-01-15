-- MySqlBackup.NET 2.3.8.0
-- Dump Time: 2024-12-18 18:17:32
-- --------------------------------------
-- Server version 10.4.20-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of user
-- 

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FelhasznaloNev` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `TeljesNev` varchar(60) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `SALT` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `HASH` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Email` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Jogosultsag` int(1) NOT NULL,
  `Aktiv` int(1) NOT NULL,
  `RegisztracioDatuma` datetime DEFAULT current_timestamp(),
  `ProfilKepUtvonal` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `FelhasznaloNev` (`FelhasznaloNev`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- 
-- Dumping data for table user
-- 

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user`(`Id`,`FelhasznaloNev`,`TeljesNev`,`SALT`,`HASH`,`Email`,`Jogosultsag`,`Aktiv`,`RegisztracioDatuma`,`ProfilKepUtvonal`) VALUES(1,'LakatosI','Lakatos István','jQGX8grO1yjNqhiZbtROcseiqj1NVZJd2iqlfxPx1GKLJ9H8smnLJ9dloScCK6Zp','dcedbd2d352d19c6eae0dfb12271b74d985c825b8d774afd2abd0d101b6e57ef','lakatosi@gmail.com',9,1,'2024-11-25 07:33:49',''),(5,'string','string','string','473287f8298dba7163a897908958f7c0eae733e25d2e027992ea2edc9bed2fa8','kerenyir@kkszki.hu',0,0,'2024-12-18 16:33:14','string');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2024-12-18 18:17:32
-- Total time: 0:0:0:0:99 (d:h:m:s:ms)
