   M S B A M L   `   `   `  ����M  IProjetoIntegradorI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjetoIntegradorI.EleitorProjetoIntegradorI.Eleitor  5   	   (    "ProjetoIntegradorI.Eleitor.Eleitor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:ProjetoIntegradorI.Eleitor     5   	     � Title$  Eleitor��5   	   $	��450��6   $	��800��6&   .��5	      � ���	#FFABABAB.+�5
   
   �� -   5         ��Name$ 	lblEstado��5
      $��Votação do Estado - ��6#   $
��Left=�6B   $��	10,25,0,0q�6]   $	��Top=�6p   $��62��6�   $	��774��6�   $��Center=�6�   $��36(�6�   �� 5   
   -   5         ��Name$ voltar��5      $��Voltar��6!   $
��Left=�62   $��
62,377,0,0q�6M   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5        $ 
lblVotacao��5      $��Digite seu voto abaixo:��6$   $
��Left=�6F   $��323,110,0,0q�6a   $	��Top=�6v   �� 5   
   -   5         ��Name$ 
txtVotacao��5      $
��Left=�6&   $	��100��6A   $��294,141,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��193��6�   $��72(�6�   $��Center=�6�    � Cursor$
 None��6�   �� 5   
   -   5        $ lblCPF��5      $*��$Seu CPF: (Digite apenas os números)��6    $
��Left=�6N   $��
35,110,0,0q�6i   $	��Top=�6}   �� 5   
   -   5        $ txtCPF��5      $
��Left=�6"   $��33��6=   $��
35,141,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��203��6�   $��Center=�6�   ���	#FF564F4F �� 	IsEnabled . $��20(�6�   �� 5   
   -   5        $ confirma��5      $��CONFIRMA��6#   $
��Left=�66   $��680,344,0,0q�6Q   $	��Top=�6f   $��75��6~   
���   ����	#FF277F10
�������$��52��6�   6�   �� 5   
   -   5        $ lblNacional��5      $��Candidato Nacional��6%   $
��Left=�6B   $��323,246,0,0q�6]   $	��Top=�6r   $	��131��6�   $��Center=�6�   �� 5   
   -	   5        $ txtVotacaoRegional��5      $
��Left=�6.   $	��100��6I   $��524,141,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $	��193��6�   $��72(�6�   $��Center=�6�   $
 None��6�   �� 5   
   -
   5        $ lblRegional��5      $��Candidato Regional��6%   $
��Left=�6B   $��552,246,0,0q�6]   $	��Top=�6r   $	��131��6�   $��Center=�6�   �� 5   
   -   5        $ lblCPFobrigatorio��5      $��CPF obrigatório!��6+   $
��Left=�6F   $��
82,179,0,0q�6a   $	��Top=�6u   ���	#FFFD01016�   �� 5   
   -   5        $ lblVotoObrigatorio��5      $!��Voto Nacional obrigatório!��6,   $
��Left=�6Q   $��313,292,0,0q�6l   $	��Top=�6�   ���	#FFFD01016�   �� 5   
   -   5        $ lblVotoRegObrigatorio��5      $!��Voto Regional obrigatório!��6/   $
��Left=�6T   $��552,292,0,0q�6o   $	��Top=�6�   ���	#FFFD01016�   �� 5   
   -   5         ��Name$ 
chkBrancoN��5      $��Branco��6'   $
��Left=�68   $��357,272,0,0q�6S   $	��Top=�6h   6�   �� 5   
   -   5        $ 
chkBrancoR��5      $��Branco��6'   $
��Left=�68   $��585,272,0,0q�6S   $	��Top=�6h   6�   �� 5   
   -   5        $ lblCPFvalidacao��5      $
��Left=�6)   $��
52,174,0,0q�6D   $	��Top=�6X   ���	#FFFD01016p   �� 5   
   -   5        $ lblVotoValidacao��5      $(��"Apenas números ou voto em branco!��6*   $
��Left=�6V   $��313,292,0,0q�6q   $	��Top=�6�   ���	#FFFD01016�   �� 5   
   -   5        $ lblVotoRegValidacao��5      $'��!Apenas números ou vot em branco!��6-   $
��Left=�6X   $��552,292,0,0q�6s   $	��Top=�6�   ���	#FFFD01016�   �� 5   
   -   5        $ lblCPFdigitos��5      $$��Digite exatamente 11 dígitos!��6'   $
��Left=�6O   $��
62,179,0,0q�6j   $	��Top=�6~   
���  ��6�   5      5      