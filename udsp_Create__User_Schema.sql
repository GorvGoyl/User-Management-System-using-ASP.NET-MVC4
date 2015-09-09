CREATE TABLE `user_data` (
  `UserAutoId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(45) DEFAULT NULL,
  `UserName` varchar(45) DEFAULT NULL,
  `FullName` varchar(45) DEFAULT NULL,
  `Phone` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `Dob` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`UserAutoId`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;
