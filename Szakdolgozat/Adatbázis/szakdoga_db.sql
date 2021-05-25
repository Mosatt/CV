-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Gép: mysql.omega:3306
-- Létrehozás ideje: 2021. Ápr 09. 09:36
-- Kiszolgáló verziója: 5.6.48
-- PHP verzió: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `szakdoga_db`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `budget`
--

CREATE TABLE `budget` (
  `ID` int(11) NOT NULL,
  `storage_money` int(11) NOT NULL,
  `storage_food` int(11) NOT NULL,
  `storage_building_material` int(11) NOT NULL,
  `storage_textile` int(11) NOT NULL,
  `storage_weapon` int(11) NOT NULL,
  `cost_money` int(11) NOT NULL,
  `cost_food` int(11) NOT NULL,
  `cost_building_material` int(11) NOT NULL,
  `cost_textile` int(11) NOT NULL,
  `cost_weapon` int(11) NOT NULL,
  `market_money` int(11) NOT NULL,
  `market_food` int(11) NOT NULL,
  `market_building_material` int(11) NOT NULL,
  `market_textile` int(11) NOT NULL,
  `market_weapon` int(11) NOT NULL,
  `tax` int(3) NOT NULL,
  `health_cost` int(11) NOT NULL,
  `education_cost` int(11) NOT NULL,
  `public_safety_cost` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `budget`
--

INSERT INTO `budget` (`ID`, `storage_money`, `storage_food`, `storage_building_material`, `storage_textile`, `storage_weapon`, `cost_money`, `cost_food`, `cost_building_material`, `cost_textile`, `cost_weapon`, `market_money`, `market_food`, `market_building_material`, `market_textile`, `market_weapon`, `tax`, `health_cost`, `education_cost`, `public_safety_cost`) VALUES
(1, 103284, 1580, 1030, 1020, 1000, 5000, 0, 70, 0, 0, 0, 0, 0, 0, 0, 32, 500, 900, 500),
(2, 500000, 1000, 1000, 1000, 1000, 1500, 101, 25, 11, 0, 100, 0, 0, 0, 0, 20, 350, 220, 270),
(3, 10000, 100, 100, 100, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 300, 300, 300),
(4, 10000, 100, 100, 100, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 300, 300, 300),
(5, 10000, 100, 100, 100, 50, 0, 203, 0, 23, 0, 0, 0, 0, 0, 0, 20, 300, 300, 300);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `buildings`
--

CREATE TABLE `buildings` (
  `ID` int(11) NOT NULL,
  `building_name` varchar(50) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `tech_age` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `type` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `money_price` int(7) NOT NULL,
  `building_material_price` int(5) NOT NULL,
  `money_product` int(5) NOT NULL,
  `food_product` int(5) NOT NULL,
  `building_material_product` int(5) NOT NULL,
  `textile_product` int(5) NOT NULL,
  `weapon_product` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `buildings`
--

INSERT INTO `buildings` (`ID`, `building_name`, `tech_age`, `type`, `money_price`, `building_material_price`, `money_product`, `food_product`, `building_material_product`, `textile_product`, `weapon_product`) VALUES
(1, 'Farm', 'Középkor', 'food', 1500, 25, 0, 100, 0, 0, 0),
(2, 'Malom', 'Középkor', 'food', 1700, 15, 0, 70, 0, 0, 0),
(3, 'Legelő', 'Középkor', 'food, textile', 1400, 0, 0, 40, 0, 10, 0),
(4, 'Kőbánya', 'Középkor', 'building_material', 2000, 10, 0, 0, 25, 0, 0),
(5, 'Erdő', 'Középkor', 'building_material', 1350, 5, 0, 0, 15, 0, 0),
(6, 'Szabó céh', 'Középkor', 'textile', 1400, 30, 0, 0, 0, 25, 0),
(7, 'Kis kovács céh', 'Középkor', 'weapon', 2000, 35, 0, 0, 0, 0, 20),
(8, 'Nagy kovács céh', 'Középkor', 'weapon', 3500, 60, 0, 0, 0, 0, 30),
(9, 'Laktanya', 'Középkor', '', 2000, 35, 0, 0, 0, 0, 0),
(10, 'Íjász Lőtér', 'Középkor', '', 1800, 30, 0, 0, 0, 0, 0),
(11, 'Istálló', 'Középkor', '', 2500, 30, 0, 0, 0, 0, 0),
(12, 'Ágyúöntő műhely', 'Középkor', '', 3000, 35, 0, 0, 0, 0, 0),
(13, 'Hadi Kikötő', 'Középkor', '', 5000, 70, 0, 0, 0, 0, 0),
(14, 'Őrtorony', 'Középkor', '', 3000, 100, 0, 0, 0, 0, 0),
(15, 'Erődítmény', 'Középkor', '', 7000, 170, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `countrys`
--

CREATE TABLE `countrys` (
  `ID` int(11) NOT NULL,
  `country_name` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `form_of_government` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `tech_age` varchar(20) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `plain` int(5) NOT NULL,
  `hill` int(5) NOT NULL,
  `mountain` int(5) NOT NULL,
  `sunshine_hours_class` int(2) NOT NULL,
  `population` int(11) NOT NULL,
  `population_change` int(11) NOT NULL,
  `beach` tinyint(1) NOT NULL,
  `currency_name` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `currency_value` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `countrys`
--

INSERT INTO `countrys` (`ID`, `country_name`, `form_of_government`, `tech_age`, `plain`, `hill`, `mountain`, `sunshine_hours_class`, `population`, `population_change`, `beach`, `currency_name`, `currency_value`) VALUES
(1, 'Tesztország', 'Királyság', 'Középkor', 3500, 2500, 4000, 3, 1043525, 19027, 0, 'Dínár', 100),
(2, 'Tesztország2', 'Királyság', 'Középkor', 1500, 3500, 2000, 5, 500000, 46425, 1, 'Dínár', 100),
(3, 'Anglia', 'Monarchia', 'Középkor', 1500, 3500, 4000, 3, 1000000, 0, 1, 'Font', 100),
(4, 'Magyar Királyság', 'Királyság', 'Középkor', 4500, 2500, 3000, 3, 1000000, 0, 1, 'Korona', 100),
(5, 'Az Avignoni Pápa Rezidenciája', 'Királyság', 'Középkor', 1000, 1000, 3000, 4, 1000000, -19360, 1, 'Korona', 100);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `expected_resources`
--

CREATE TABLE `expected_resources` (
  `ID` int(11) NOT NULL,
  `money` int(11) NOT NULL,
  `food` int(11) NOT NULL,
  `building_material` int(11) NOT NULL,
  `textile` int(11) NOT NULL,
  `weapon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `expected_resources`
--

INSERT INTO `expected_resources` (`ID`, `money`, `food`, `building_material`, `textile`, `weapon`) VALUES
(1, 103284, 1580, 1030, 1020, 1000),
(2, 499340, 1479, 990, 1009, 1000),
(3, 0, 0, 0, 0, 0),
(4, 0, 0, 0, 0, 0),
(5, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `marketplace`
--

CREATE TABLE `marketplace` (
  `ID` int(11) NOT NULL,
  `country_name` varchar(45) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `country_id` int(11) NOT NULL,
  `sell_material` varchar(20) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `sell_amount` int(11) NOT NULL,
  `get_money` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `marketplace`
--

INSERT INTO `marketplace` (`ID`, `country_name`, `country_id`, `sell_material`, `sell_amount`, `get_money`) VALUES
(10, 'Tesztország', 1, 'Élelmiszer', 100, 2000),
(11, 'Tesztország', 1, 'Építoanyag', 100, 1000);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `messages`
--

CREATE TABLE `messages` (
  `ID` int(11) NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `sender_country` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `adresse_country` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `subject` varchar(20) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `text` varchar(2000) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `read_status` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `messages`
--

INSERT INTO `messages` (`ID`, `date`, `sender_country`, `adresse_country`, `subject`, `text`, `read_status`) VALUES
(1, '2021-03-16 19:08:43', 'Tesztország', 'Tesztország2', 'próba üzenet', 'Üdv!\r\nEz egy próba üzenet akar lenni.', 1),
(2, '2021-02-28 13:26:44', 'Tesztország', 'Tesztország2', 'próba2', 'új próba üzenet', 1),
(3, '2021-03-17 17:06:09', 'Tesztország2', 'Tesztország', 'próba3', 'még egy üzi', 1),
(4, '2021-03-17 17:05:50', 'Tesztország2', 'Tesztország', 'próbálkozás 4', 'próba 4444', 1),
(5, '2021-02-28 13:26:42', 'Tesztország', 'Tesztország2', 'algut nkrusonitnfdga', 'Szállj el kismadár\r\nNézd meg, hogy merre jár\r\nMondd el, hogy merre járhat Ő\r\n\r\nMondd el, hogy szeretem\r\nMondd el, hogy kell nekem\r\nMondd el, hogy semmi más nem kell\r\n\r\nCsak a Hold az égen\r\nCsak a Nap ragyogjon\r\nSimogasson a szél\r\nSimogasson, ha arcomhoz ér\r\nCsak a Hold ragyogjon\r\nCsak a Nap az égen\r\nNekem semmi más nem kell\r\n\r\nKell, hogy rátalálj\r\nSzállj el kismadár\r\nNézd meg, hogy merre járhat Ő!\r\n\r\nVidd el a levelem\r\nMondd el, hogy kell nekem\r\nMondd el, hogy semmi más nem kell\r\n\r\nCsak a hold az égen\r\nCsak a nap ragyogjon\r\nSimogasson a szél\r\nSimogasson, ha arcomhoz ér\r\nCsak a hold ragyogjon\r\nCsak a nap az égen\r\nNekem semmi más nem kell\r\n\r\nSoha ne gyere, ha most nem jössz\r\nSoha ne szeress, ha most nem vagy itt\r\nSoha ne gyere, ha most nem jössz\r\nSoha ne szeress, ha most nem vagy itt\r\n\r\nCsak a Hold az égen\r\nCsak a Nap ragyogjon\r\nSimogasson a szél\r\nSimogasson, ha arcomhoz ér\r\nCsak a Hold ragyogjon\r\nCsak a Nap az égen\r\nNekem semmi más nem kell', 1),
(6, '2021-03-07 23:00:00', 'Az Avignoni Pápa Rezidenciája', 'Anglia', 'próba üzenet', 'Üdv, ez egy próba üzenet!', 0),
(7, '2021-03-16 18:59:34', 'Tesztország2', 'Tesztország2', 'próbálás', '123123123', 1),
(9, '2021-03-17 17:13:08', 'Tesztország2', 'Tesztország', 'próba12345', 'próbálkozás', 1),
(12, '2021-03-17 17:32:03', 'Tesztország', 'Tesztország2', 'ethdthdrthdrhdrh', 'segaefaethjh', 1),
(14, '2021-03-17 17:46:27', 'Tesztország', 'Tesztország2', '1234', 'asffhgmnh', 1),
(15, '2021-03-17 18:04:01', 'Tesztország', 'Tesztország2', 'próba üzenet', 'próba üzenet\r\npróba üzenet\r\npróba üzenet\r\npróba üzenet', 1),
(16, '2021-03-20 16:57:20', 'Tesztország2', 'Tesztország', 'RE: próba üzenet', '\n\n\n------------------------------------------------------------------------------------------------------------------------\npróba üzenet\r\npróba üzenet\r\npróba üzenet\r\npróba üzenet', 0),
(17, '2021-03-20 17:52:06', 'Tesztország2', 'Az Avignoni Pápa Rezidenciája', '999', 'pkoökoö', 0),
(18, '2021-03-25 18:38:37', 'Tesztország', 'Tesztország2', 'próba', 'skdfjgb hbg sd\r\ndsg ndG\r\nSDG\r\nSDG\r\n \r\n\r\n\r\nGSDGDSGWE\r\nsdg \r\nsd\r\ng\r\nweg\r\nesgf\r\ndsgsdgnhvbkwk ek gdks bgkwe gnksdgn lwrjkg', 1),
(19, '2021-03-27 09:36:22', 'Tesztország', 'Tesztország2', 'próba üzenet 1234556', 'fbsdnb\r\ndb sd\r\nb sd\r\nb\r\nsdvbsdbhmsdhvbsdgvj \r\ndsvdvsd', 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `userID` int(11) NOT NULL,
  `username` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `password` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `status` varchar(5) COLLATE utf8mb4_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`userID`, `username`, `password`, `status`) VALUES
(1, 'teszt', '1472429833', 'admin'),
(2, 'teszt2', '1472429833', 'user'),
(3, 'anglia', '1472429833', 'user'),
(4, 'magyarkir', '1472429833', 'user'),
(5, 'avignon', '1472429833', 'user');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users_buildings`
--

CREATE TABLE `users_buildings` (
  `ID` int(11) NOT NULL,
  `b_Farm` int(11) NOT NULL,
  `b_Mill` int(11) NOT NULL,
  `b_Pasture` int(11) NOT NULL,
  `b_Quarry` int(11) NOT NULL,
  `b_Forest_built` int(11) NOT NULL,
  `b_Tailor_guild` int(11) NOT NULL,
  `b_Little_blacksmith_guild` int(11) NOT NULL,
  `b_Great_blacksmith_guild` int(11) NOT NULL,
  `b_Barrack` int(11) NOT NULL,
  `b_Archery_school` int(11) NOT NULL,
  `b_Stable` int(11) NOT NULL,
  `b_Cannon_foundry` int(11) NOT NULL,
  `b_Military_port` int(11) NOT NULL,
  `b_Watchtower` int(11) NOT NULL,
  `b_Fortress` int(11) NOT NULL,
  `c_Farm` int(11) NOT NULL,
  `c_Mill` int(11) NOT NULL,
  `c_Pasture` int(11) NOT NULL,
  `c_Quarry` int(11) NOT NULL,
  `c_Forest` int(11) NOT NULL,
  `c_Tailor_guild` int(11) NOT NULL,
  `c_Little_blacksmith_guild` int(11) NOT NULL,
  `c_Great_blacksmith_guild` int(11) NOT NULL,
  `c_Barrack` int(11) NOT NULL,
  `c_Archery_school` int(11) NOT NULL,
  `c_Stable` int(11) NOT NULL,
  `c_Cannon_foundry` int(11) NOT NULL,
  `c_Military_port` int(11) NOT NULL,
  `c_Watchtower` int(11) NOT NULL,
  `c_Fortress` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `users_buildings`
--

INSERT INTO `users_buildings` (`ID`, `b_Farm`, `b_Mill`, `b_Pasture`, `b_Quarry`, `b_Forest_built`, `b_Tailor_guild`, `b_Little_blacksmith_guild`, `b_Great_blacksmith_guild`, `b_Barrack`, `b_Archery_school`, `b_Stable`, `b_Cannon_foundry`, `b_Military_port`, `b_Watchtower`, `b_Fortress`, `c_Farm`, `c_Mill`, `c_Pasture`, `c_Quarry`, `c_Forest`, `c_Tailor_guild`, `c_Little_blacksmith_guild`, `c_Great_blacksmith_guild`, `c_Barrack`, `c_Archery_school`, `c_Stable`, `c_Cannon_foundry`, `c_Military_port`, `c_Watchtower`, `c_Fortress`) VALUES
(1, 5, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0),
(2, 5, 0, 2, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(3, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(4, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(5, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `budget`
--
ALTER TABLE `budget`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `buildings`
--
ALTER TABLE `buildings`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `countrys`
--
ALTER TABLE `countrys`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `expected_resources`
--
ALTER TABLE `expected_resources`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `marketplace`
--
ALTER TABLE `marketplace`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userID`);

--
-- A tábla indexei `users_buildings`
--
ALTER TABLE `users_buildings`
  ADD PRIMARY KEY (`ID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `budget`
--
ALTER TABLE `budget`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `buildings`
--
ALTER TABLE `buildings`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT a táblához `countrys`
--
ALTER TABLE `countrys`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `expected_resources`
--
ALTER TABLE `expected_resources`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `marketplace`
--
ALTER TABLE `marketplace`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT a táblához `messages`
--
ALTER TABLE `messages`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `users_buildings`
--
ALTER TABLE `users_buildings`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
