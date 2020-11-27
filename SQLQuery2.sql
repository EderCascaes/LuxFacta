CREATE TABLE SURVEY(
	[poll_id] INT  PRIMARY KEY ,
	[poll_description]  NVARCHAR(100) NOT NULL,    
	  
);

CREATE TABLE OPTION_SURVEY(
	[option_id] INT   PRIMARY KEY ,
	[option_description]  NVARCHAR(100) NOT NULL,    
	[poll_id] NVARCHAR(11)  references SURVEY(poll_id) ,
	[qtd_Votos] INT,
);