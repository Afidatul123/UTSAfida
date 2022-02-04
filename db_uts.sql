/*
SQLyog Ultimate v13.1.1 (64 bit)
MySQL - 10.1.37-MariaDB : Database - db_uts
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_uts` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `db_uts`;

/*Table structure for table `__efmigrationshistory` */

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `__efmigrationshistory` */

insert  into `__efmigrationshistory`(`MigrationId`,`ProductVersion`) values 
('20220201103209_tb_roles','5.0.13'),
('20220201103825_tb_users','5.0.13'),
('20220203074111_tb_jadwal','5.0.13');

/*Table structure for table `tb_jadwal` */

DROP TABLE IF EXISTS `tb_jadwal`;

CREATE TABLE `tb_jadwal` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `pelatihan` text,
  `TglMulai` datetime NOT NULL,
  `TglSelesai` datetime NOT NULL,
  `pertemuan` text,
  `Tutor` text,
  `Keterangan` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tb_jadwal` */

/*Table structure for table `tb_roles` */

DROP TABLE IF EXISTS `tb_roles`;

CREATE TABLE `tb_roles` (
  `Id` varchar(767) NOT NULL,
  `Name` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_roles` */

insert  into `tb_roles`(`Id`,`Name`) values 
('1','Admin'),
('2','User');

/*Table structure for table `tb_user` */

DROP TABLE IF EXISTS `tb_user`;

CREATE TABLE `tb_user` (
  `Username` varchar(767) NOT NULL,
  `Password` text,
  `Nama` text,
  `Email` text,
  `RolesId` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Username`),
  KEY `IX_Tb_User_RolesId` (`RolesId`),
  CONSTRAINT `FK_Tb_User_Tb_Roles_RolesId` FOREIGN KEY (`RolesId`) REFERENCES `tb_roles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tb_user` */

insert  into `tb_user`(`Username`,`Password`,`Nama`,`Email`,`RolesId`) values 
('Admin','adm123','Admin','adm12@gmail.com','1'),
('afida','af098','afi','afida.maghfiroh8@gmail.com','2'),
('coba','coba123','cobalagi','cblg123@gmail.com','1');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
