WatchDog .Net log Monitoring with Postgresql

Bug:'WatchDogSettings' does not contain a definition for 'SqlDriverOption' and no accessible extension method 'SqlDriverOption' accepting a first argument of type 'WatchDogSettings' could be found (are you missing a using directive or an assembly reference?)

Solution:opt.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.PostgreSql;
