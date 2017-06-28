-----------------------------------------------------------------------
-- 							O2 - BASE  
-----------------------------------------------------------------------

spool 02_REST_CORE_PKG.log
set define off
set feedback off


Prompt Creating package PKG_USER
--     =========================

CREATE OR REPLACE PACKAGE BODY PKG_USER
IS

   PROCEDURE p_count (p_count_o OUT NUMBER)
   IS
   BEGIN
      SELECT COUNT (*) INTO p_count_o FROM USERS;

   EXCEPTION
      WHEN OTHERS
      THEN
          RAISE;

   END p_count;


   PROCEDURE p_ins (pOBJ_USER_i IN OBJ_USER,
                    p_USER_ID_o OUT USERS.USER_ID%TYPE)
   IS
   BEGIN

      INSERT INTO USERS (USER_ID,
                         USER_NAME,
                         BIRTHDAY_DATE)
             VALUES (
                        SEQ_USERS.NEXTVAL,
                        POBJ_USER_i.USER_NAME,
                        POBJ_USER_i.BIRTHDAY_DATE)
		     RETURNING USER_ID INTO p_USER_ID_o;

   EXCEPTION
      WHEN OTHERS
      THEN
          RAISE;

   END p_ins;


   PROCEDURE p_upd (pOBJ_USER_i IN OBJ_USER)
   IS
   BEGIN

      UPDATE USERS
         SET USER_NAME = POBJ_USER_i.USER_NAME,
             BIRTHDAY_DATE = POBJ_USER_i.BIRTHDAY_DATE
       WHERE USERS.USER_ID = pOBJ_USER_i.USER_ID;

   EXCEPTION
      WHEN OTHERS
      THEN
          RAISE;

   END p_upd;


   PROCEDURE p_del (p_USER_ID_i IN USERS.USER_ID%TYPE)
   IS
   BEGIN

      DELETE USERS
       WHERE USERS.USER_ID = p_USER_ID_i;

   EXCEPTION
      WHEN OTHERS
      THEN
          RAISE;

   END p_del;


   PROCEDURE P_GET_BY_ID (p_USER_ID_i   IN     USERS.USER_ID%TYPE,
                          pcur_USER_o OUT SYS_REFCURSOR) AS
   BEGIN
     
     OPEN pcur_USER_o FOR
       SELECT USER_ID, USER_NAME, BIRTHDAY_DATE
       FROM USERS
       WHERE USER_ID = p_USER_ID_i;

   END P_GET_BY_ID;


   PROCEDURE P_GET_ALL (pcur_USER_o OUT SYS_REFCURSOR) AS
      
   BEGIN

     OPEN pcur_USER_o FOR
       SELECT USER_ID, USER_NAME, BIRTHDAY_DATE
       FROM USERS
       ORDER BY USER_ID;
       
   END P_GET_ALL;

END PKG_USER;

/

prompt Done. 
set feedback on
set define on
spool off