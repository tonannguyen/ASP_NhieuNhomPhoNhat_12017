Create database do_an_asp;


create table m_types(
	type_id		int IDENTITY(1,1)PRIMARY KEY,
	name		varchar(50),
	create_time datetime,
	update_time datetime
	
);

create table m_flowers(
	flower_id	int IDENTITY(1,1) PRIMARY KEY,
	type_id		int,
	name		varchar(50),
	price		float,
	quantity	int,
	create_time datetime,
	update_time datetime,
	CONSTRAINT FK_FlowerType FOREIGN KEY (type_id)
    REFERENCES m_types(type_id)
);

create table t_postions(
	pos_id		int IDENTITY(1,1) PRIMARY KEY,
	value		varchar(50),
	create_time datetime,
	update_time datetime
);

create table m_staff(
	staff_id	int IDENTITY(1,1)PRIMARY KEY,
	name		varchar(50),
	phone		int,
	adress		varchar(100),
	position	int,
	salary		float,
	bonus		float,
	create_time datetime,
	update_time datetime,
	CONSTRAINT FK_StaffPosition FOREIGN KEY (position)
    REFERENCES t_postions(pos_id)
	
	
);

create table m_revenue(
	id					int PRIMARY KEY,
	year_id				int,
	quantity_of_date	float,
	quantiry_of_week	float,
	quantity_of_month	float,
	quantity_of_quater	float,
	quantity_of_year	float,
	create_time			datetime,
	update_time			datetime
);