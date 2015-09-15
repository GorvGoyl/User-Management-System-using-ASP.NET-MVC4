CREATE TABLE `USER_DATA` (
  `UserAutoId` int(11) NULL AUTO_INCREMENT,
  `UserId` varchar(60) NOT NULL,
  `UserName` varchar(45) DEFAULT NULL,
  `FullName` varchar(45) DEFAULT NULL,
  `Phone` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `Dob` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  CONSTRAINT  UserId   PRIMARY KEY (UserId)  ,
  CONSTRAINT  UserAutoId  UNIQUE (UserAutoId)
) ;