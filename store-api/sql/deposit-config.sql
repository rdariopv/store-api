



drop table vopdp
create table vopdp(             -- ventas online --parametros  de deposito en cuenta
	vopdpNitm	integer,		-- numero de item del registro
	vopdpDpdp	varchar(60), 	-- descripcion del deposito o instruccion del deposito 
	vopdpNBco	VARCHAR(30), 	-- nombre banco deposito
	vopdpNcta	VARCHAR(20), 	-- NUMERO DE CUENTA 
	vopdpNomc	varchar(40),	-- nombre titular de la cuenta 
	vopdpTcta	VARCHAR(20),	-- tipo de cuenta  ej. cuenta de ahorro CA, cuenta corriente CC
	vopdpCmon	integer,		-- codigo moneda de cuenta
	vopdpDmon	varchar(20),	-- descripcion moneda
	vopdpStat 	integer,		-- estado del registro 
	vopdpRide	integer,		-- reg. log bitacora
	
);


INSERT INTO vopdp
(
    vopdpDpdp,
    vopdpNBco,
    vopdpNcta,
    vopdpNomc,
    vopdpTcta,
    vopdpCmon,
    vopdpDmon,
    vopdpStat,
    vopdpRide
)
VALUES
(
    'Realizar el depósito e indicar el número de pedido.',
    'Banco de prueba',
    '000123456789',
    'EMPRESA COMERCIAL S.R.L.',
    'CC',
    1,
    'BOB',
    0,
    20261015
);