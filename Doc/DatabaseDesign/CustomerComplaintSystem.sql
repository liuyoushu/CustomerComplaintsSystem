/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2014/3/21 14:55:16                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CaseInfo') and o.name = 'FK_CASEINFO_START_COMPLAIN')
alter table CaseInfo
   drop constraint FK_CASEINFO_START_COMPLAIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Company') and o.name = 'FK_COMPANY_HAVE_DEPARTME')
alter table Company
   drop constraint FK_COMPANY_HAVE_DEPARTME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ComplaintDisposeAndFeedbackInfo') and o.name = 'FK_COMPLAIN_FEEDBACK_CASEINFO')
alter table ComplaintDisposeAndFeedbackInfo
   drop constraint FK_COMPLAIN_FEEDBACK_CASEINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ComplaintDisposeAndFeedbackInfo') and o.name = 'FK_COMPLAIN_受理 填写_STAFF')
alter table ComplaintDisposeAndFeedbackInfo
   drop constraint "FK_COMPLAIN_受理 填写_STAFF"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ComplaintInfo') and o.name = 'FK_COMPLAIN_COMPLAINT_BUSINESS')
alter table ComplaintInfo
   drop constraint FK_COMPLAIN_COMPLAINT_BUSINESS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ComplaintInfo') and o.name = 'FK_COMPLAIN_RECEIVE_CASEINFO')
alter table ComplaintInfo
   drop constraint FK_COMPLAIN_RECEIVE_CASEINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ComplaintReturnVisitInfo') and o.name = 'FK_COMPLAIN_RETURNVIS_CASEINFO')
alter table ComplaintReturnVisitInfo
   drop constraint FK_COMPLAIN_RETURNVIS_CASEINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ComplaintReturnVisitInfo') and o.name = 'FK_COMPLAIN_投诉回访_STAFF')
alter table ComplaintReturnVisitInfo
   drop constraint FK_COMPLAIN_投诉回访_STAFF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Department') and o.name = 'FK_DEPARTME_MANAGE_BUSINESS')
alter table Department
   drop constraint FK_DEPARTME_MANAGE_BUSINESS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('History') and o.name = 'FK_HISTORY_REFERENCE_CASEINFO')
alter table History
   drop constraint FK_HISTORY_REFERENCE_CASEINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('History') and o.name = 'FK_HISTORY_REFERENCE_STAFF')
alter table History
   drop constraint FK_HISTORY_REFERENCE_STAFF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ImportantEvent_Center') and o.name = 'FK_IMPORTAN_SPECIALHA_CASEINFO')
alter table ImportantEvent_Center
   drop constraint FK_IMPORTAN_SPECIALHA_CASEINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ImportantEvent_Center') and o.name = 'FK_IMPORTAN_重大事件总处理_STAFF')
alter table ImportantEvent_Center
   drop constraint FK_IMPORTAN_重大事件总处理_STAFF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ImportantEvent_Department') and o.name = 'FK_IMPORTAN_ASSIGN_IMPORTAN')
alter table ImportantEvent_Department
   drop constraint FK_IMPORTAN_ASSIGN_IMPORTAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ImportantEvent_Department') and o.name = 'FK_IMPORTAN_特殊处理_部门负责_CASEINFO')
alter table ImportantEvent_Department
   drop constraint FK_IMPORTAN_特殊处理_部门负责_CASEINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ImportantEvent_Department') and o.name = 'FK_IMPORTAN_重大事件部门处理_STAFF')
alter table ImportantEvent_Department
   drop constraint FK_IMPORTAN_重大事件部门处理_STAFF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ImportantEvent_Staff') and o.name = 'FK_IMPORTAN_DESIGNATE_IMPORTAN')
alter table ImportantEvent_Staff
   drop constraint FK_IMPORTAN_DESIGNATE_IMPORTAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ImportantEvent_Staff') and o.name = 'FK_IMPORTAN_特殊处理_员工_CASEINFO')
alter table ImportantEvent_Staff
   drop constraint FK_IMPORTAN_特殊处理_员工_CASEINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ImportantEvent_Staff') and o.name = 'FK_IMPORTAN_重大事件处理_STAFF')
alter table ImportantEvent_Staff
   drop constraint FK_IMPORTAN_重大事件处理_STAFF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Staff') and o.name = 'FK_STAFF_BELONG_BUSINESS')
alter table Staff
   drop constraint FK_STAFF_BELONG_BUSINESS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Staff') and o.name = 'FK_STAFF_OCCUPY_POSITION')
alter table Staff
   drop constraint FK_STAFF_OCCUPY_POSITION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Business')
            and   type = 'U')
   drop table Business
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CaseInfo')
            and   name  = 'Start_FK'
            and   indid > 0
            and   indid < 255)
   drop index CaseInfo.Start_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CaseInfo')
            and   type = 'U')
   drop table CaseInfo
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Company')
            and   name  = 'have_FK'
            and   indid > 0
            and   indid < 255)
   drop index Company.have_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Company')
            and   type = 'U')
   drop table Company
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Complainer')
            and   type = 'U')
   drop table Complainer
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ComplaintDisposeAndFeedbackInfo')
            and   name  = '受理 填写_FK'
            and   indid > 0
            and   indid < 255)
   drop index ComplaintDisposeAndFeedbackInfo."受理 填写_FK"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ComplaintDisposeAndFeedbackInfo')
            and   name  = 'feedback_FK'
            and   indid > 0
            and   indid < 255)
   drop index ComplaintDisposeAndFeedbackInfo.feedback_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ComplaintDisposeAndFeedbackInfo')
            and   type = 'U')
   drop table ComplaintDisposeAndFeedbackInfo
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ComplaintInfo')
            and   name  = 'complaintTarget_FK'
            and   indid > 0
            and   indid < 255)
   drop index ComplaintInfo.complaintTarget_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ComplaintInfo')
            and   name  = 'receive_FK'
            and   indid > 0
            and   indid < 255)
   drop index ComplaintInfo.receive_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ComplaintInfo')
            and   type = 'U')
   drop table ComplaintInfo
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ComplaintReturnVisitInfo')
            and   name  = '投诉回访_FK'
            and   indid > 0
            and   indid < 255)
   drop index ComplaintReturnVisitInfo.投诉回访_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ComplaintReturnVisitInfo')
            and   name  = 'returnVisit_FK'
            and   indid > 0
            and   indid < 255)
   drop index ComplaintReturnVisitInfo.returnVisit_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ComplaintReturnVisitInfo')
            and   type = 'U')
   drop table ComplaintReturnVisitInfo
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Department')
            and   name  = 'manage_FK'
            and   indid > 0
            and   indid < 255)
   drop index Department.manage_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Department')
            and   type = 'U')
   drop table Department
go

if exists (select 1
            from  sysobjects
           where  id = object_id('History')
            and   type = 'U')
   drop table History
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ImportantEvent_Center')
            and   name  = '重大事件总处理_FK'
            and   indid > 0
            and   indid < 255)
   drop index ImportantEvent_Center.重大事件总处理_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ImportantEvent_Center')
            and   name  = 'specialHandling2_FK'
            and   indid > 0
            and   indid < 255)
   drop index ImportantEvent_Center.specialHandling2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ImportantEvent_Center')
            and   type = 'U')
   drop table ImportantEvent_Center
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ImportantEvent_Department')
            and   name  = '特殊处理_部门负责人_FK'
            and   indid > 0
            and   indid < 255)
   drop index ImportantEvent_Department.特殊处理_部门负责人_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ImportantEvent_Department')
            and   name  = '重大事件部门处理_FK'
            and   indid > 0
            and   indid < 255)
   drop index ImportantEvent_Department.重大事件部门处理_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ImportantEvent_Department')
            and   name  = 'assign_FK'
            and   indid > 0
            and   indid < 255)
   drop index ImportantEvent_Department.assign_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ImportantEvent_Department')
            and   type = 'U')
   drop table ImportantEvent_Department
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ImportantEvent_Staff')
            and   name  = '特殊处理_员工_FK'
            and   indid > 0
            and   indid < 255)
   drop index ImportantEvent_Staff.特殊处理_员工_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ImportantEvent_Staff')
            and   name  = '重大事件处理_FK'
            and   indid > 0
            and   indid < 255)
   drop index ImportantEvent_Staff.重大事件处理_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ImportantEvent_Staff')
            and   name  = 'designate_FK'
            and   indid > 0
            and   indid < 255)
   drop index ImportantEvent_Staff.designate_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ImportantEvent_Staff')
            and   type = 'U')
   drop table ImportantEvent_Staff
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Position')
            and   type = 'U')
   drop table Position
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Staff')
            and   name  = 'occupy_FK'
            and   indid > 0
            and   indid < 255)
   drop index Staff.occupy_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Staff')
            and   name  = 'belong_FK'
            and   indid > 0
            and   indid < 255)
   drop index Staff.belong_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Staff')
            and   type = 'U')
   drop table Staff
go

/*==============================================================*/
/* Table: Business                                              */
/*==============================================================*/
create table Business (
   BussinessID          int                  identity,
   BussinessName        char(20)             not null,
   BussinessDescribe    text                 null,
   constraint PK_BUSINESS primary key nonclustered (BussinessID)
)
go

/*==============================================================*/
/* Table: CaseInfo                                              */
/*==============================================================*/
create table CaseInfo (
   ID                   int                  identity,
   Com_ID               int                  not null,
   ArchiveDate          datetime             null,
   State                int                  not null,
   constraint PK_CASEINFO primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Index: Start_FK                                              */
/*==============================================================*/
create index Start_FK on CaseInfo (
Com_ID ASC
)
go

/*==============================================================*/
/* Table: Company                                               */
/*==============================================================*/
create table Company (
   CompanyID            int                  identity,
   DepartmentID         int                  not null,
   CompanyName          varchar(50)          not null,
   Province             varchar(20)          not null,
   City                 varchar(20)          null,
   County               varchar(20)          null,
   DetailedAddress      varchar(50)          not null,
   SuperiorComID        int                  null,
   constraint PK_COMPANY primary key nonclustered (CompanyID)
)
go

/*==============================================================*/
/* Index: have_FK                                               */
/*==============================================================*/
create index have_FK on Company (
DepartmentID ASC
)
go

/*==============================================================*/
/* Table: Complainer                                            */
/*==============================================================*/
create table Complainer (
   ID                   int                  identity,
   PhoneNumber          char(11)             not null,
   Email                varchar(30)          null,
   Name                 varchar(30)          not null,
   constraint PK_COMPLAINER primary key nonclustered (ID)
)
go

/*==============================================================*/
/* Table: ComplaintDisposeAndFeedbackInfo                       */
/*==============================================================*/
create table ComplaintDisposeAndFeedbackInfo (
   CptDF_ID             int                  identity,
   Stf_ID               char(11)             not null,
   ID                   int                  not null,
   CptDF_Solution       text                 null,
   CptDF_Content        text                 null,
   CptDF_Satisfaction   int                  null,
   CptDF_BeginTime      datetime             null,
   CptDF_EndTime        datetime             null,
   constraint PK_COMPLAINTDISPOSEANDFEEDBACK primary key nonclustered (CptDF_ID)
)
go

/*==============================================================*/
/* Index: feedback_FK                                           */
/*==============================================================*/
create index feedback_FK on ComplaintDisposeAndFeedbackInfo (
ID ASC
)
go

/*==============================================================*/
/* Index: "受理 填写_FK"                                            */
/*==============================================================*/
create index "受理 填写_FK" on ComplaintDisposeAndFeedbackInfo (
Stf_ID ASC
)
go

/*==============================================================*/
/* Table: ComplaintInfo                                         */
/*==============================================================*/
create table ComplaintInfo (
   Cpt_InfoID           int                  identity,
   ID                   int                  not null,
   BussinessID          int                  null,
   Cpt_Way              varchar(10)          not null,
   Cpt_Date             datetime             not null,
   Cpt_Area             varchar(50)          null,
   Cpt_Class            varchar(20)          null,
   Cpt_Describe         text                 not null,
   Cpt_BeginTime        datetime             null,
   Cpt_EndTime          datetime             null,
   constraint PK_COMPLAINTINFO primary key nonclustered (Cpt_InfoID)
)
go

/*==============================================================*/
/* Index: receive_FK                                            */
/*==============================================================*/
create index receive_FK on ComplaintInfo (
ID ASC
)
go

/*==============================================================*/
/* Index: complaintTarget_FK                                    */
/*==============================================================*/
create index complaintTarget_FK on ComplaintInfo (
BussinessID ASC
)
go

/*==============================================================*/
/* Table: ComplaintReturnVisitInfo                              */
/*==============================================================*/
create table ComplaintReturnVisitInfo (
   CptReVst_ID          int                  identity,
   ID                   int                  not null,
   Stf_ID               char(11)             not null,
   CptReVst_Date        datetime             null,
   CptReVst_Content     text                 null,
   CptReVst_IsSolved    bit                  null,
   CptReVst_CptReason   text                 null,
   CptReVst_BeginTime   datetime             null,
   CptReVst_EndTime     datetime             null,
   constraint PK_COMPLAINTRETURNVISITINFO primary key nonclustered (CptReVst_ID)
)
go

/*==============================================================*/
/* Index: returnVisit_FK                                        */
/*==============================================================*/
create index returnVisit_FK on ComplaintReturnVisitInfo (
ID ASC
)
go

/*==============================================================*/
/* Index: 投诉回访_FK                                               */
/*==============================================================*/
create index 投诉回访_FK on ComplaintReturnVisitInfo (
Stf_ID ASC
)
go

/*==============================================================*/
/* Table: Department                                            */
/*==============================================================*/
create table Department (
   DepartmentID         int                  identity,
   BussinessID          int                  not null,
   DepartmentName       char(20)             not null,
   Describe             text                 not null,
   DepartmentPhoneNum   varchar(15)          not null,
   DepartmentRemark     text                 null,
   constraint PK_DEPARTMENT primary key nonclustered (DepartmentID)
)
go

/*==============================================================*/
/* Index: manage_FK                                             */
/*==============================================================*/
create index manage_FK on Department (
BussinessID ASC
)
go

/*==============================================================*/
/* Table: History                                               */
/*==============================================================*/
create table History (
   History_ID           int                  identity,
   ID                   int                  null,
   Stf_ID               char(11)             null,
   History_Process      text                 not null,
   History_HandleTime   datetime             not null,
   constraint PK_HISTORY primary key (History_ID)
)
go

/*==============================================================*/
/* Table: ImportantEvent_Center                                 */
/*==============================================================*/
create table ImportantEvent_Center (
   IptEvt_C_ID          int                  identity,
   Stf_ID               char(11)             not null,
   ID                   int                  not null,
   IptEvt_C_Solution    text                 not null,
   IptEvt_C_BeginDate   datetime             null,
   IptEvt_C_EndDate     datetime             null,
   IptEvt_C_Conclusion  text                 null,
   constraint PK_IMPORTANTEVENT_CENTER primary key nonclustered (IptEvt_C_ID)
)
go

/*==============================================================*/
/* Index: specialHandling2_FK                                   */
/*==============================================================*/
create index specialHandling2_FK on ImportantEvent_Center (
ID ASC
)
go

/*==============================================================*/
/* Index: 重大事件总处理_FK                                            */
/*==============================================================*/
create index 重大事件总处理_FK on ImportantEvent_Center (
Stf_ID ASC
)
go

/*==============================================================*/
/* Table: ImportantEvent_Department                             */
/*==============================================================*/
create table ImportantEvent_Department (
   IptEvt_D_ID          int                  identity,
   Stf_ID               char(11)             not null,
   IptEvt_C_ID          int                  not null,
   ID                   int                  not null,
   IptEvt_D_Duty        text                 null,
   IptEvt_D_Conclusion  text                 null,
   IptEvt_D_BeginTime   datetime             null,
   IptEvt_D_EndTime     datetime             null,
   constraint PK_IMPORTANTEVENT_DEPARTMENT primary key nonclustered (IptEvt_D_ID)
)
go

/*==============================================================*/
/* Index: assign_FK                                             */
/*==============================================================*/
create index assign_FK on ImportantEvent_Department (
IptEvt_C_ID ASC
)
go

/*==============================================================*/
/* Index: 重大事件部门处理_FK                                           */
/*==============================================================*/
create index 重大事件部门处理_FK on ImportantEvent_Department (
Stf_ID ASC
)
go

/*==============================================================*/
/* Index: 特殊处理_部门负责人_FK                                         */
/*==============================================================*/
create index 特殊处理_部门负责人_FK on ImportantEvent_Department (
ID ASC
)
go

/*==============================================================*/
/* Table: ImportantEvent_Staff                                  */
/*==============================================================*/
create table ImportantEvent_Staff (
   IptEvt_S_ID          int                  identity,
   Stf_ID               char(11)             not null,
   ID                   int                  not null,
   IptEvt_D_ID          int                  not null,
   IptEvt_S_Content     text                 null,
   IptEvt_S_BeginTime   datetime             null,
   IptEvt_S_EndTime     datetime             null,
   constraint PK_IMPORTANTEVENT_STAFF primary key nonclustered (IptEvt_S_ID)
)
go

/*==============================================================*/
/* Index: designate_FK                                          */
/*==============================================================*/
create index designate_FK on ImportantEvent_Staff (
IptEvt_D_ID ASC
)
go

/*==============================================================*/
/* Index: 重大事件处理_FK                                             */
/*==============================================================*/
create index 重大事件处理_FK on ImportantEvent_Staff (
Stf_ID ASC
)
go

/*==============================================================*/
/* Index: 特殊处理_员工_FK                                            */
/*==============================================================*/
create index 特殊处理_员工_FK on ImportantEvent_Staff (
ID ASC
)
go

/*==============================================================*/
/* Table: Position                                              */
/*==============================================================*/
create table Position (
   Post_ID              int                  identity,
   Post_Name            char(20)             not null,
   Post_Content         text                 not null,
   Post_Remark          text                 null,
   Post_SuperiorID      int                  null,
   constraint PK_POSITION primary key nonclustered (Post_ID)
)
go

/*==============================================================*/
/* Table: Staff                                                 */
/*==============================================================*/
create table Staff (
   Stf_ID               char(11)             not null,
   BussinessID          int                  null,
   Post_ID              int                  null,
   Stf_Name             varchar(20)          not null,
   Stf_Gender           tinyint              not null,
   Stf_Age              int                  not null,
   Stf_IdentifyCardNum  char(18)             not null,
   Stf_EntryTime        datetime             not null,
   constraint PK_STAFF primary key nonclustered (Stf_ID)
)
go

/*==============================================================*/
/* Index: belong_FK                                             */
/*==============================================================*/
create index belong_FK on Staff (
BussinessID ASC
)
go

/*==============================================================*/
/* Index: occupy_FK                                             */
/*==============================================================*/
create index occupy_FK on Staff (
Post_ID ASC
)
go

alter table CaseInfo
   add constraint FK_CASEINFO_START_COMPLAIN foreign key (Com_ID)
      references Complainer (ID)
go

alter table Company
   add constraint FK_COMPANY_HAVE_DEPARTME foreign key (DepartmentID)
      references Department (DepartmentID)
go

alter table ComplaintDisposeAndFeedbackInfo
   add constraint FK_COMPLAIN_FEEDBACK_CASEINFO foreign key (ID)
      references CaseInfo (ID)
go

alter table ComplaintDisposeAndFeedbackInfo
   add constraint "FK_COMPLAIN_受理 填写_STAFF" foreign key (Stf_ID)
      references Staff (Stf_ID)
go

alter table ComplaintInfo
   add constraint FK_COMPLAIN_COMPLAINT_BUSINESS foreign key (BussinessID)
      references Business (BussinessID)
go

alter table ComplaintInfo
   add constraint FK_COMPLAIN_RECEIVE_CASEINFO foreign key (ID)
      references CaseInfo (ID)
go

alter table ComplaintReturnVisitInfo
   add constraint FK_COMPLAIN_RETURNVIS_CASEINFO foreign key (ID)
      references CaseInfo (ID)
go

alter table ComplaintReturnVisitInfo
   add constraint FK_COMPLAIN_投诉回访_STAFF foreign key (Stf_ID)
      references Staff (Stf_ID)
go

alter table Department
   add constraint FK_DEPARTME_MANAGE_BUSINESS foreign key (BussinessID)
      references Business (BussinessID)
go

alter table History
   add constraint FK_HISTORY_REFERENCE_CASEINFO foreign key (ID)
      references CaseInfo (ID)
go

alter table History
   add constraint FK_HISTORY_REFERENCE_STAFF foreign key (Stf_ID)
      references Staff (Stf_ID)
go

alter table ImportantEvent_Center
   add constraint FK_IMPORTAN_SPECIALHA_CASEINFO foreign key (ID)
      references CaseInfo (ID)
go

alter table ImportantEvent_Center
   add constraint FK_IMPORTAN_重大事件总处理_STAFF foreign key (Stf_ID)
      references Staff (Stf_ID)
go

alter table ImportantEvent_Department
   add constraint FK_IMPORTAN_ASSIGN_IMPORTAN foreign key (IptEvt_C_ID)
      references ImportantEvent_Center (IptEvt_C_ID)
go

alter table ImportantEvent_Department
   add constraint FK_IMPORTAN_特殊处理_部门负责_CASEINFO foreign key (ID)
      references CaseInfo (ID)
go

alter table ImportantEvent_Department
   add constraint FK_IMPORTAN_重大事件部门处理_STAFF foreign key (Stf_ID)
      references Staff (Stf_ID)
go

alter table ImportantEvent_Staff
   add constraint FK_IMPORTAN_DESIGNATE_IMPORTAN foreign key (IptEvt_D_ID)
      references ImportantEvent_Department (IptEvt_D_ID)
go

alter table ImportantEvent_Staff
   add constraint FK_IMPORTAN_特殊处理_员工_CASEINFO foreign key (ID)
      references CaseInfo (ID)
go

alter table ImportantEvent_Staff
   add constraint FK_IMPORTAN_重大事件处理_STAFF foreign key (Stf_ID)
      references Staff (Stf_ID)
go

alter table Staff
   add constraint FK_STAFF_BELONG_BUSINESS foreign key (BussinessID)
      references Business (BussinessID)
go

alter table Staff
   add constraint FK_STAFF_OCCUPY_POSITION foreign key (Post_ID)
      references Position (Post_ID)
go

