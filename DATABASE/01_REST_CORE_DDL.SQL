-----------------------------------------------------------------------
-- 							O1 - BASE 
-----------------------------------------------------------------------
spool 01_REST_CORE_DDL.log
set feedback off
set define on

ACCEPT TB_DATA CHAR DEFAULT FIBAUKXXDO PROMPT 'Enter name for tablespace for data in tables (default FIBAUKXXDO):'
ACCEPT TB_INDEXS CHAR DEFAULT FIBAUKXXIO PROMPT 'Enter name for tablespace for indexes (default FIBAUKXXIO):'
ACCEPT TB_LOBS CHAR DEFAULT FIBAUKXXLO PROMPT 'Enter name for tablespace for LOB data (default FIBAUKXXLO):'

Prompt Type OBJ_USER;
CREATE OR REPLACE TYPE OBJ_USER FORCE AS OBJECT(
   USER_ID NUMBER,
   USER_NAME  VARCHAR2 (300 CHAR),
   BIRTHDAY_DATE DATE
)
/

Prompt Table USERS;
CREATE TABLE USERS
(
  USER_ID                   NUMBER,
  USER_NAME                 VARCHAR2(300 CHAR),
  BIRTHDAY_DATE             DATE
)
TABLESPACE &TB_DATA
NOPARALLEL
/

COMMENT ON TABLE USERS IS 'Table stores application users accounts'
/

COMMENT ON COLUMN USERS.USER_ID IS 'Primary key'
/

COMMENT ON COLUMN USERS.USER_NAME IS 'User Name'
/

COMMENT ON COLUMN USERS.BIRTHDAY_DATE IS 'Account birthdate date'
/

Prompt Index PK_USERS;
CREATE UNIQUE INDEX PK_USERS ON USERS
(USER_ID)
TABLESPACE &TB_INDEXS
NOPARALLEL
/

ALTER TABLE USERS
 ADD CONSTRAINT PK_USERS
  PRIMARY KEY
  (USER_ID)
  USING INDEX PK_USERS
/

Prompt Sequence SEQ_USERS;
CREATE SEQUENCE SEQ_USERS
  START WITH 6
  MAXVALUE 999999999999999999999999999
  MINVALUE 1
  NOCYCLE
  NOCACHE
  NOORDER
/

prompt Done. 
set feedback on
set define on
spool off