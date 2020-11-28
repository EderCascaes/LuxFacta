
https://github.com/EderCascaes/LuxFacta


1. Qual foi a parte mais difícil na solução do desafio?
	Não comprendi muito bem a parte de montar a View

2. Se você pudesse voltar no tempo e se dar um conselho no início do desafio, qual
seria?
	No votar não verifica se a opção escolhida existe, somente a Enquete

3. Se você pudesse mudar algo na proposta/definição do desafio, o que seria?
	Talves retornar  o porcentagem de votos para cada opção com seu posicionamento,
	tipo:

		"options": [
		{1°, "option_id": 2, "option_description":  40%},
		{2°, "option_id": 3, "option_description":  35%},
		{3°, "option_id": 1, "option_description":  25%},
       ]




CREATE TABLE SURVEY(
	[poll_id] INT  PRIMARY KEY NOT NULL ,
	[poll_description]  NVARCHAR(1000) NOT NULL,    
	[counter] INT DEFAULT  0 
	  
);

CREATE TABLE OPTION_SURVEY(
	[option_id] INT   IDENTITY(1,1)  PRIMARY KEY ,
	[option_description]  NVARCHAR(500) NOT NULL,    
	[poll_id] INT   references SURVEY(poll_id) NOT NULL ,
	[qtd_Votos] INT  DEFAULT  0,
	[position] INT NOT NULL
);













enquetes usadas de testes


{
	 "poll_description": "Qual Time vai ser Campeão Brasileiro da série A de 2020 ? ",
	 "options": [
	 "CR FLAMENTO",
	 "SÃO PAULO FC",
	 "EC PALMEIRAS"
	 ]
}

{    
	 "poll_description": "Qual sua Cor preferida ? ",
	 "options": [
	 "VERMELHO",
	 "AZUL",
	 "VERDE"
	 ]
}


{
	 "poll_description": "Qual sua escolaridade/cursando ? ",
	 "options": [
	 "PRIMARIO",
	 "MÉDIO",
	 "SUPERIOR"
	 ]
}


{
	 "poll_description": "Qual é a melhor liguagem de programação ? ",
	 "options": [
	 "CSharp",
	 "Python",
	 "Java"
	 ]
}