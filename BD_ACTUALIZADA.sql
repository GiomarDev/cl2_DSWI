USE MASTER 
GO

IF DB_ID('BD_EDITORIAL') IS NOT NULL	
	DROP DATABASE BD_EDITORIAL
GO

CREATE DATABASE BD_EDITORIAL
GO

USE BD_EDITORIAL
GO

SET DATEFORMAT DMY
GO


CREATE TABLE PAIS (
  IDE_PAI 	INT				NOT NULL PRIMARY KEY IDENTITY(1,1),
  NOM_PAI	VARCHAR(40) 	NOT NULL
  )
GO

INSERT INTO PAIS(NOM_PAI) VALUES
('PERU'),
('ARGENTINA'),
('CHILE'),
('USA'),
('ESPAÑA'),
('FRANCIA'),
('COLOMBIA'),
('CANADA'),
('CHINA')
GO

CREATE TABLE AUTOR (
  IDE_AUT	INT 			NOT NULL PRIMARY KEY IDENTITY(1,1),
  NOM_AUT	VARCHAR(40) 	NOT NULL,
  IDE_PAI	INT	 			REFERENCES PAIS,
  COR_AUT	VARCHAR(50)		NOT NULL,
  FON_AUT	VARCHAR(25) 	NOT NULL
)
GO

INSERT INTO AUTOR(NOM_AUT,IDE_PAI,COR_AUT,FON_AUT) VALUES
('JAMES BLOOM', '1', 'JBLOOM@GMAIL.COM', '010-9852147852'),
('CARLOS STEIN', '2', 'CSTEIN@GMAIL.COM', '010-5656232211'),
('JORGE ROJAS', '4', 'JROJAS@GMAIL.COM', '010-9852022225'),
('ERNESTO TIRADO', '1', 'ETIRADO@GMAIL.COM', '010-9995222244')
GO

CREATE TABLE LIBRO(
 IDE_LIB	INT			NOT NULL PRIMARY KEY IDENTITY(1,1),
 AUT_LIB	VARCHAR(50)	NOT NULL,	--AUTOR
 TIT_LIB	VARCHAR(75)	NOT NULL,	--TITULO DEL LIBRO
 ISB_LIB	VARCHAR(13)	NOT NULL,	--NUMERO ISBN
 EDI_LIB	VARCHAR(30)	NOT NULL,	--EDITORIAL
 AÑO_LIB	INT			NOT NULL,	--AÑO DE EDICION,
 COS_LIB	MONEY		NOT NULL,	--COSTO
 CAN_LIB	INT			NOT NULL,	--CANTIDAD DEL LIBRO
 FOT_LIB	VARCHAR(50) NOT NULL	--FOTO
)
GO

INSERT INTO LIBRO(AUT_LIB,TIT_LIB,ISB_LIB,EDI_LIB,AÑO_LIB,COS_LIB,CAN_LIB,FOT_LIB) VALUES
('Thomas G. Field','Beef Production and management Decisions','9788492946259','Pearson','2018','40','10','~/FOTOLIBRO/1.JPG'),
('Gert Wagner, José Díaz, Rolf Lüders','CHILE 1810-2010. La República en cifras','9788492946260','Ediciones UC','2016','30','10','~/FOTOLIBRO/2.JPG'),
('Jensen, Eric','Cerebro y Aprendizaje. Competencias e implicaciones educativas','9788492946261','Narcea','2010','35','10','~/FOTOLIBRO/3.JPG'),
('Picazo, Gloria y Ribalta, Jorge ed.','Efecto Real. Debates postmodernos sobre fotografía.','9788492946262','Gustavo Gili','2004','75','10','~/FOTOLIBRO/4.JPG'),
('INRA','INRA feeding system for ruminants','9788492946263','Wageningen Academic Publisher','2018','35','10','~/FOTOLIBRO/5.JPG'),
('André Rouillé','La Fotografía. Entre documento y arte contemporáneo','9788492946264','Herder','2017','75','10','~/FOTOLIBRO/6.JPG'),
('Charles Moore, Jenny Dooley','Career Paths: Journalism','9788492946265','Express Publishing','2015','35','10','~/FOTOLIBRO/7.JPG'),
('Carlos Hassey','Animal Breeding and Livestock Management','9788492946266','Syrawood Publishing House','2017','40','10','~/FOTOLIBRO/8.JPG'),
('Fuller W. Bazer, G. Cliff Lamb, Guoyao Wu','Animal Agriculture: Sustainability, Challenges and Innovations','9788492946267','Academic Press','2019','75','10','~/FOTOLIBRO/9.JPG'),
('Thomas G. Field','Beef Production and Management Decisions','9788492946268','Pearson','2017','30','10','~/FOTOLIBRO/10.JPG'),
('Andy Herring','Beef Cattle Production Systems','9788492946269','CABI','2014','40','10','~/FOTOLIBRO/11.JPG'),
('Dominic Fasso','Genetic Management of Animals','9788492946270','Syrawood Publishing House','2019','35','10','~/FOTOLIBRO/12.JPG'),
('Max Van Manen','El tacto en la enseñanza','9788492946271','Paidos','1998','50','10','~/FOTOLIBRO/13.JPG'),
('Max Van Manen','Investigación Educativa y experiencia vivida','9788492946272','Idea Books','2003','50','10','~/FOTOLIBRO/14.JPG'),
('Virginia Evans & Kori Salcido','Nursing','9788492946273','Express Publishing','2011','40','10','~/FOTOLIBRO/15.JPG'),
('Brigitte Markner-Jäger','Technical English for Geosciences','9788492946274','Springer','2008','50','10','~/FOTOLIBRO/16.JPG'),
('Schlegelmilch, Bodo','Global Marketing Strategy. An Executive Digest','9788492946275','Springer','2016','30','10','~/FOTOLIBRO/17.JPG'),
('KEEGAN, WARREN J. - GREEN, MARK C.','GLOBAL MARKETING','9788492946276','PEARSON','2017','35','10','~/FOTOLIBRO/18.JPG'),
('Cristina de Pizán','La ciudad de las damas','9788492946277','Siruela','2018','75','10','~/FOTOLIBRO/19.JPG'),
('Richard M. Hopper','Bovine Reproduction','9788492946278','Wiley Blackbell','2014','35','10','~/FOTOLIBRO/20.JPG'),
('David E. Noakes, Timothy J. Parkinson','Veterinary Reproduction and Obstetrics','9788492946279','Elsevier','2019','30','10','~/FOTOLIBRO/21.JPG'),
('P.L. Senger','Pathways pregnancy & parturition','9788492946280','Current Conceptions, Inc.','2012','40','10','~/FOTOLIBRO/22.JPG'),
('Josep Asensio','El desarrollo del tacto pedagógico','9788492946281','Barcelona ','2010','40','10','~/FOTOLIBRO/23.JPG'),
('Antonio J. Colom Cañellas','La (de)construcción del conocimiento pedagógico. ','9788492946282','Barcelona ','2002','40','10','~/FOTOLIBRO/24.JPG'),
('Bernardo Blejmar','Gestionar es hacer que las cosas sucedan','9788492946283','Buenos Aires','2014','120','10','~/FOTOLIBRO/25.JPG')
GO