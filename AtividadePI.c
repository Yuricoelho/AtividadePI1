#include <stdio.h>
#include <stdlib.h>
#include <locale.h>

int main(){
        int qtd_prefeito, qtd_deputado, qtd_governador, qtd_votantes, 
        DensidadeDemografica, qtd_habitantes, area_local, FaixaEtaria,
        RendaBruta, NivelFundamental, NivelMedio, NivelSuperior, RacaNegra,
        RacaBranca, RacaAmarela;
    
        FILE *arq;
        FILE *p;
        
        setlocale(LC_ALL, "Portuguese");
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
        printf("Densidade demogrC!fica: ");
        scanf("%d", &DensidadeDemografica);
        printf("\nFaixa EtC!ria: ");
        scanf("%d", &FaixaEtaria);
        printf("\nRenda Bruta: ");
        scanf("%d", &RendaBruta);
        printf("\nNC-vel fundamental: ");
        scanf("%d", &NivelFundamental);
        printf("\nNC-vel mC)dio: ");
        scanf("%d", &NivelMedio);
        printf("\nNC-vel superior: ");
        scanf("%d", &NivelSuperior);
        printf("\nQuantidade de candidatos para o cargo de prefeito: ");
        scanf("%d", &qtd_prefeito);

        arq = fopen ("Relatorio.txt", "a");

        while(arq != NULL){
            p = (FILE*) malloc(sizeof(arq));
            fprintf(arq, "Prefeito: %d\n Deputado: %d\n Governador: %d\n Quantidade de votantes: %d\n Densidade demográfica: %d\n Faixa etária: %d\n Renda bruta: %d\n Escolaridade: %d\n Raça: %d", qtd_prefeito, qtd_deputado, qtd_governador, qtd_votantes, 
            DensidadeDemografica, qtd_habitantes, area_local, FaixaEtaria,
            RendaBruta, NivelFundamental, NivelMedio, NivelSuperior, RacaBranca, RacaNegra, RacaAmarela);
        }
        fclose(arq);
        free(arq); 
        p = NULL;
return 0;
}
