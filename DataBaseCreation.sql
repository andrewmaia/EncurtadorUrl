CREATE DATABASE `encurtadorurl` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_general_ci */;

use encurtadorurl;

CREATE TABLE `user` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;


CREATE TABLE `url` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Hits` int(11) NOT NULL,
  `FullUrl` varchar(1000) COLLATE latin1_general_ci NOT NULL,
  `ShortUrl` varchar(100) COLLATE latin1_general_ci NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `ID_idx` (`UserID`),
  CONSTRAINT `ID` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;



