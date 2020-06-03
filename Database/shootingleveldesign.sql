-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- ホスト: localhost
-- 生成日時: 2020 年 5 月 08 日 11:48
-- サーバのバージョン： 10.4.11-MariaDB
-- PHP のバージョン: 7.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- データベース: `tasksystem`
--

-- --------------------------------------------------------

--
-- テーブルの構造 `shootingleveldesign`
--

CREATE TABLE `shootingleveldesign` (
  `Number` int(11) NOT NULL,
  `Level` int(11) NOT NULL,
  `Pattern` int(11) NOT NULL,
  `PosX` int(11) NOT NULL,
  `PosY` int(11) NOT NULL,
  `PosZ` int(11) NOT NULL,
  `RateX` int(11) NOT NULL,
  `RateY` int(11) NOT NULL,
  `RateZ` int(11) NOT NULL,
  `ScaleX` int(11) NOT NULL,
  `ScaleY` int(11) NOT NULL,
  `ScaleZ` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- テーブルのデータのダンプ `shootingleveldesign`
--

INSERT INTO `shootingleveldesign` (`Number`, `Level`, `Pattern`, `PosX`, `PosY`, `PosZ`, `RateX`, `RateY`, `RateZ`, `ScaleX`, `ScaleY`, `ScaleZ`) VALUES
(1, 1, 1, -15, 1, 0, 0, 145, 0, 1, 1, 1),
(2, 1, 1, 0, 1, 5, 0, 0, 0, 1, 1, 1),
(3, 1, 1, 15, 1, 0, 0, 45, 0, 1, 1, 1),
(4, 2, 1, -12, 1, 20, 0, 165, 0, 1, 1, 1),
(5, 2, 1, 12, 1, 20, 0, 15, 0, 1, 1, 1),
(6, 3, 2, 0, 1, 15, 0, 0, 0, 1, 1, 1),
(7, 4, 2, 15, 1, 15, 0, 0, 0, 1, 1, 1),
(8, 4, 2, -15, 1, 15, 0, 0, 0, 1, 1, 1),
(9, 5, 1, 0, 1, 30, 0, 180, 0, 1, 1, 1),
(10, 6, 2, -30, 1, 30, 0, 0, 0, 1, 1, 1),
(11, 6, 2, 30, 1, 30, 0, 0, 0, 1, 1, 1),
(12, 7, 2, 0, 1, 5, 0, 0, 0, 1, 1, 1),
(13, 7, 2, 0, 1, 15, 0, 0, 0, 1, 1, 1),
(14, 7, 2, 0, 1, 25, 0, 0, 0, 1, 1, 1),
(15, 8, 1, -40, 1, -5, 0, 270, 0, 1, 1, 1),
(16, 8, 1, 40, 1, -5, 0, 270, 0, 1, 1, 1),
(17, 9, 2, 0, 1, 40, 0, 0, 0, 1, 1, 1),
(18, 10, 1, -20, 1, 40, 0, 90, 0, 1, 1, 1),
(19, 10, 1, 0, 1, 40, 0, 90, 0, 1, 1, 1),
(20, 10, 1, 20, 1, 40, 0, 90, 0, 1, 1, 1);

--
-- ダンプしたテーブルのインデックス
--

--
-- テーブルのインデックス `shootingleveldesign`
--
ALTER TABLE `shootingleveldesign`
  ADD PRIMARY KEY (`Number`);

--
-- ダンプしたテーブルのAUTO_INCREMENT
--

--
-- テーブルのAUTO_INCREMENT `shootingleveldesign`
--
ALTER TABLE `shootingleveldesign`
  MODIFY `Number` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
