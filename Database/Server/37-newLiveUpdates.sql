-- This live update simplifies the notification of items
INSERT INTO `eveliveupdates` (`updateID`, `updateName`, `description`, `machoVersionMin`, `machoVersionMax`, `buildNumberMin`, `buildNumberMax`, `methodName`, `objectID`, `codeType`, `code`) VALUES (3, 'OnGodmaPrimeItem', 'Simplifies notification of item changes', 219, 219, 101786, 101786, 'OnGodmaPrimeItem', 'svc.godma::Godma', 'globalClassMethod', 0x630300000005000000070000004300000073540000007C00006900008300007D03007C03006901007C01007C0200830200017C02006902007D04007403006904006401007C040068000004640000027406006907003C04640000027406006908003C830300016400005328020000004E740C0000004F6E4974656D4368616E67652809000000740F00000047657453746174654D616E6167657274100000004F6E476F646D615072696D654974656D7407000000696E764974656D7402000000736D740C000000536361747465724576656E7474040000004E6F6E657405000000636F6E7374740C00000069784C6F636174696F6E494474060000006978466C61672805000000740400000073656C66740A0000006C6F636174696F6E49447403000000726F77740800000073746174654D677274040000006974656D2800000000280000000073090000003C636F6E736F6C653E520200000001000000730A00000000010C01100109012B01);
-- This live update gives the inbox a better appearance
INSERT INTO `eveliveupdates` (`updateID`, `updateName`, `description`, `machoVersionMin`, `machoVersionMax`, `buildNumberMin`, `buildNumberMax`, `methodName`, `objectID`, `codeType`, `code`) VALUES (4, 'inboxtitle', 'Gives a nicer feeling to the in-game mail inbox', 219, 219, 101786, 101786, 'ShowMessage', 'svc.inbox::InboxSvc', 'globalClassMethod', 0x630300000005000000050000004300000073020100007C00006900008300007D03007C03006400006A0800700A00017C03006902006F080001640000536E0100017C00006903007C01008301005C02007D04007D02007404006905007C03006906006907006908005F09007C0300690600690700690A006401007C0400690B001764020017740C00690D007C0400690E0064030083020017640400177C0400690F0017640500640600830101017404006910007C0300690600691100830100017404006912007C03006906006911005F09007C01007C00005F13007C00006914007C01007C0400691500830200017C00006916007C040069150083010001741700691800691900691A006407007C0100830200016400005328080000004E73040000003C68313E73050000003C2F68313E74020000006C7373080000003C62723E3C62723E740B0000007363726F6C6C746F746F706901000000740C000000696E626F786C6173746D7367281B0000007406000000476574576E6474040000004E6F6E65740900000064657374726F796564740A0000004765744D6573736167657403000000756978740F00000055495F5049434B4348494C4452454E74020000007372740F000000766965776D657373616765666F726D7406000000706172656E7474050000007374617465740800000053657456616C756574070000007375626A65637474040000007574696C7407000000466D74446174657407000000637265617465647404000000626F64797405000000466C757368740B0000006174746163686D656E7473740900000055495F48494444454E740F00000073686F77696E675F6D657373616765740700000041646452656164740800000073656E6465724944740C000000436865636B427574746F6E73740800000073657474696E67737404000000636861727402000000756974030000005365742805000000740400000073656C6674090000006D657373616765494452140000007403000000776E6474030000006D73672800000000280000000073090000003C636F6E736F6C653E740B00000053686F774D65737361676501000000731A00000000010C0117010801150115014201130112010901130110011601);