# Code-Based Migration in Entity Framework 6 #

1) Enable-migrations
2) Add Migration [Migration name] => or it will generate random number
3) Update-database [-verbose] Use the –verbose option to view the SQL statements being applied to the target database

#RollBack DB

update-database -TargetMigration: Migration Name


