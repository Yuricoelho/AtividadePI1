   M S B A M L   `   `   `  ����M  IProjetoIntegradorI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProjetoIntegradorI.AdminProjetoIntegradorI.Admin  5   	   1    +ProjetoIntegradorI.Admin.CadastrarCandidato   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ProjetoIntegradorI.Admin     5   	     � Title$  CadastrarCandidato��5   	   $	��450��6$   $	��800��61   .��5	      � .+�5
   
   �� -   5         ��Name$ Voltar��5
      $��Voltar��6!   $
��Left=�62   $��
47,376,0,0q�6M   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5         ��Name$ lblNome��5      $
��Nome��6!   $
��Left=�60   $	��Top=�6K   $��
136,34,0,0q�6c   $��45��6w   $��83��6�   $��24(�6�   �� 5   
   -   5         ��Name$ txtNome��5      $
��Left=�6#   $��36��6>   $��
116,79,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��516��6�   $��24(�6�   �� 5   
   -   5        $ 	lblCodigo��5      $��Código do candidato��6#   $
��Left=�6A   $��116,172,0,0q�6\   $	��Top=�6q   $��22(�6�   $	��234��6�   �� 5   
   -   5        $ 	txtCodigo��5      $
��Left=�6%   $��43��6@   $��350,172,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��110��6�   $��22(�6�   �� 5   
   -   5        $ lblCodigoPartido��5      $��Código do partido��6*   $
��Left=�6F   $��116,260,0,0q�6a   $	��Top=�6v   $	��202��6�   $��22(�6�   �� 5   
   -   5        $ txtCodigoPartido��5      $
��Left=�6,   $��43��6G   $��350,257,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��110��6�   $��22(�6�   �� 5   
   -   5        $ lblNomeErro��5      $��Nome obrigatório!��6%   $
��Left=�6A   $��136,120,0,0q�6\   $	��Top=�6q   
���  ��6�   �� 5   
   -	   5        $ lblCodigoErro��5      $(��"Código do candidato obrigatório!��6'   $
��Left=�6R   $��350,212,0,0q�6m   $	��Top=�6�   
���  ��6�   �� 5   
   -
   5        $ lblCodigoPartidoErro��5      $&�� Código do partido obrigatório!��6.   $
��Left=�6W   $��350,305,0,0q�6r   $	��Top=�6�   
���  ��6�   �� 5   
   -   5        $ lblCodigoInvalido��5      $'��!Inválido! Digite apenas números��6+   $
��Left=�6U   $��350,212,0,0q�6p   $	��Top=�6�   
���  ��6�   �� 5   
   -   5        $ lblCodigoPartidoInvalido��5      $'��!Inválido! Digite apenas números��62   $
��Left=�6\   $��350,305,0,0q�6w   $	��Top=�6�   
���  ��6�   �� 5   
   -   5        $ btnCadastrar��5      $��	Cadastrar��6'   $
��Left=�6;   $��664,376,0,0q�6V   $	��Top=�6k   $��75��6�   6�   �� 5   
   -   5        $ lblCandidatoCadastrado��5      $��Candidato já cadastrado!��60   $
��Left=�6S   $��300,363,0,0q�6n   $	��Top=�6�   
���  ��$��16(�6�   5      5      