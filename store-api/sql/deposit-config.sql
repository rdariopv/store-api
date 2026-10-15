




create table vopdp(             -- ventas online --parametros  de deposito en cuenta
	vopdpNitm	integer,		-- numero de item del registro
	vopdpDpdp	varchar(50), 	-- descripcion del deposito o instruccion del deposito 
	vopdpNBco	VARCHAR(20), 	-- nombre banco deposito
	vopdpNcta	VARCHAR(20), 	-- NUMERO DE CUENTA 
	vopdpNomc	varchar(30),	-- nombre titular de la cuenta 
	vopdpTcta	VARCHAR(20),	-- tipo de cuenta  ej. cuenta de ahorro CA, cuenta corriente CC
	vopdpCmon	integer,		-- codigo moneda de cuenta
	vopdpDmon	varchar(10),	-- descripcion moneda
	vopdpStat 	integer,		-- estado del registro 
	vopdpRide	integer,		-- reg. log bitacora
	
);
