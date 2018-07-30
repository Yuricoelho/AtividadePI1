#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <string.h>
#include <conio.h>
/*
--Alterações Lucas Hipólito, data: 28/07/2018
Vou comentar tudo que acrescentar
*/


void clrscr()
{
    system("@cls||clear");
}

int main(){
        int qtd_prefeito, qtd_deputado, qtd_governador, qtd_votantes,
        DensidadeDemografica, qtd_habitantes, area_local, FaixaEtaria,
        RendaBruta, NivelFundamental, NivelMedio, NivelSuperior, RacaNegra,
        RacaBranca, RacaAmarela, /*Acrescentado*/menu, reset = 1, sair = 0;

        FILE *arq;
        FILE *p;

        setlocale(LC_ALL, "Portuguese");


        /*Menu Acrescentado*/
        while (reset == 1){
        	printf("Bem vindo. Selecione a funcao: ");
        	printf("\n1 - Administrativo");
        	printf ("\n2 - Eleitor");
        	printf ("\n3 - Sair\n");
        	scanf("%d", &menu);
        	if (menu != 1 && menu != 2 && menu != 3){
        		printf ("\nOpcao invalida!\nSelecione novamente.");
			}
			else if (menu == 3){
				exit(1);
			}
			else {
				reset = 0;
			}fflush(stdin);
		}

		clrscr();
 		while (sair == 0){
 		if (menu == 1){
        		printf("Quantidade de candidatos para o cargo de prefeito: ");
		        scanf("%d", &qtd_prefeito);
		        printf("\nQuantidade de candidatos para o cargo de deputado: ");
		        scanf("%d", &qtd_deputado);
		        printf("\nQuantidade de candidatos para o cargo de governador: ");
		        scanf("%d", &qtd_governador);
		        printf("\nQuantidade de candidatos para o cargo de votantes: ");
		        scanf("%d", &qtd_votantes);
		        printf("\nQuantidade de habitantes: ");
		        scanf("%d", &qtd_habitantes);
		        printf("\nQuantidade de area local: ");
		        scanf("%d", &area_local);

		        DensidadeDemografica = qtd_habitantes / area_local;
		        printf("\nFaixa etÃ¡ria: ");
		        scanf("%d", &FaixaEtaria);
		        printf("\nRenda Bruta: ");
		        scanf("%d", &RendaBruta);
		        printf("\nNÃ­vel fundamental: ");
		        scanf("%d", &NivelFundamental);
		        printf("\nNÃ­vel mC)dio: ");
		        scanf("%d", &NivelMedio);
		        printf("\nNÃ­vel superior: ");
		        scanf("%d", &NivelSuperior);
		        printf("\nQuantidade de candidatos para o cargo de prefeito: ");
		        scanf("%d", &qtd_prefeito);

		        arq = fopen ("Relatorio.txt", "a");

		        //while(arq != NULL){
		            p = (FILE*) malloc(sizeof(arq));
		            fprintf(arq, "Prefeito: %d\n Deputado: %d\n Governador: %d\n Quantidade de votantes: %d\n Densidade demogrÃ¡fica: %d\n Faixa etÃ¡ria: %d\n Renda bruta: %d\n Escolaridade: %d\n RaÃ§a: %d", qtd_prefeito, qtd_deputado, qtd_governador, qtd_votantes,
		            DensidadeDemografica, qtd_habitantes, area_local, FaixaEtaria,
		            RendaBruta, NivelFundamental, NivelMedio, NivelSuperior, RacaBranca, RacaNegra, RacaAmarela);
		        //}
		        fclose(arq);
		        free(arq);
		        p = NULL;
		        sair = 1;
			}
			/*Deste ponto em diante foi adicionado por Lucas Hipolito*/
	        if (menu ==2){
	        	char nome[50];
	        	int idade;
	        	int escolaridadeN;
	        	char escolaridade[50];
	        	float renda;

	        	printf ("\nPrezado eleitor, favor identifique-se:\n");

	        	printf ("\nNome:\n");
	        	gets(nome);
	        	fflush (stdin);
	        	printf ("\n\nIdade:\n");
	        	scanf ("%d", &idade);

	        	int auxiliar = 0;

	        	printf ("\n\nEscolaridade:");
	        	printf ("\n1 - Nivel Fundamental incompleto.\n2 - Nivel Fundamental completo.\n3 - Nivel Medio incompleto.\n4 - Nivel Medio Completo.\n5 - Nivel Superior incompleto.\n6 - Nivel Superior Completo.\n7 - Pos-Graduacao.\n");
	        	while (auxiliar == 0){
	        		printf("\n");
					scanf("%d", &escolaridadeN);
	        		switch (escolaridadeN){
	        			case 1:
	        				auxiliar = 1;
	        				strcpy(escolaridade, "Nivel Fundamental incompleto");
	        				break;
        				case 2:
        					strcpy(escolaridade,"Nivel Fundamental completo");
        					auxiliar = 1;
        					break;
	        			case 3:
	        				strcpy(escolaridade,"Nivel Medio incompleto");
	        				auxiliar = 1;
							break;
						case 4:
							strcpy(escolaridade, "Nivel Medio Completo");
							auxiliar = 1;
							break;
						case 5:
							strcpy(escolaridade, "Nivel Superior incompleto");
							auxiliar = 1;
							break;
						case 6:
							strcpy(escolaridade,"Nivel Superior Completo");
							auxiliar = 1;
							break;
						case 7:
							strcpy(escolaridade,"Pos-Graduacao");
							auxiliar = 1;
							break;
						default:
							printf ("Opcao invalida!\nSelecione novamente.");
							auxiliar = 0;
							break;
					}
				}

	        	printf("\n\nRenda bruta mensal: (Use virgula caso necessario)\n");
	        	scanf ("%f", &renda);

	        	clrscr();
	        	printf ("\nMuito obrigado por preencher suas informacoes.\n______________________________________________________\nFaca seus votos:\n");
	        	printf ("\nPrefeito:");
	        	printf ("\n<(Inserir lista de candidatos prefeito)>");
	        	//scanf("%d", &numeroCandidatoPrefeito);
	        	printf ("\n\nDeputado:");
	        	printf ("<(Inserir lista de candidatos deputado)>");
	        	//scanf("%d", &numeroCandidatoDeputado);
	        	printf ("\n\nGovernador:");
	        	printf ("\n<(Inserir lista de candidatos governador)>");
	        	//scanf("%d", &numeroCandidatoGovernador);

	        	//system("pause");

	        	arq = fopen ("Eleitores.txt", "a");

		        //while(arq != EOF){
		            p = (FILE*) malloc(sizeof(arq));
		            fprintf(arq, "Eleitor(a): %s\nIdade: %d\nEscolaridade: %s\nRenda: %.2f\nVoto prefeito: %d\nVoto Deputado: %d\nVoto Governador: %d\n_______________________________\n", nome, idade, escolaridade, renda,/*substituir voto prefeito*/ 0, /*sustituir voto deputado*/ 0, /*substituir voto governador*/0);
		        //}
		        fclose(arq);
		        free(arq);
		        p = NULL;
		        printf ("\n\nDeseja sair ou votar novamente?\n");
		        printf ("1 - Sair\n0 - Votar novamente\n");
		        scanf("%d", &sair);
		}
	}
return 0;
}
