-----------------------------------------------------------------------
-- 							O3 - BASE  
-----------------------------------------------------------------------
spool 03_REST_CORE_MASTER_DATA.log
set feedback off
set define off

prompt Loading USERS...
insert into USERS (USER_ID, USER_NAME, BIRTHDAY_DATE) values (1, 'User1', to_date('29-04-1975', 'dd-mm-yyyy'));
insert into USERS (USER_ID, USER_NAME, BIRTHDAY_DATE) values (2, 'User2', to_date('19-04-1974', 'dd-mm-yyyy'));
insert into USERS (USER_ID, USER_NAME, BIRTHDAY_DATE) values (3, 'User3', to_date('18-07-1982', 'dd-mm-yyyy'));
insert into USERS (USER_ID, USER_NAME, BIRTHDAY_DATE) values (4, 'User4', to_date('03-12-1979', 'dd-mm-yyyy'));
insert into USERS (USER_ID, USER_NAME, BIRTHDAY_DATE) values (5, 'User5', to_date('10-03-1987', 'dd-mm-yyyy'));

commit;

prompt Done. 
set feedback on
set define on
spool off