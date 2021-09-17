CREATE DATABASE `azami`;

use azami;

CREATE TABLE `logs` (
  `ServerId` varchar(100),
  `MessageId` varchar(100),
  `UserId` varchar(100),
  `UserName` varchar(100),
  `ChannelId` varchar(100),
  `Message` longtext,
  `Date` datetime DEFAULT NULL,
  PRIMARY KEY (`MessageId`)
);
