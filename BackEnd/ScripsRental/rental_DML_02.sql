USE T_RENTAL;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Localiza'), ('Unidas')

INSERT INTO MARCA (nomeMarca)
VALUES ('FORD'),('HYUNDAI')

INSERT INTO MODELO (idMarca, nomeModelo)
VALUES (1, 'Ford Mustang'), (1, 'Ford KA'), (2,'HB20'), (2,'Sonata')

INSERT INTO VEICULO (idModelo, idEmpresa, placa)
VALUES (1, 1, '137289'), (4, 2,'774455')


INSERT INTO CLIENTE (nomeCliente, sobrenomeCliente, cpfCliente)
VALUES ('Nayara','Nogueira','6543489910'),('Saulo','Love','48239089')

INSERT INTO ALUGUEL (idVeiculo, idCliente, dataInicio, dataFim)
VALUES (1, 1, '12/10/2021 09:00','31/12/2022 09:00' ),(2, 2, '20/08/2020 18:00','31/12/2021 18:00')