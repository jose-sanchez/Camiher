   M S B A M L   `   `   `  ����  AdministrationCenter8    2Camiher.UI.AdministrationCenter.NotificationClient   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NotificationClient��5   	   $	��300��6$   $	��900��61   .��5      � ��5      �� 5       �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6-   .��5   	   �  � Color$ Black��6    � Offset$ 0Q�6$   � 5	   	   $ 	#FFDC1212��6   $ 1Q�6(   5
   	   .+�5   
   �� -   5         ��Name$ addlist��5      $	��163��6$   $��Bottom=�61   $��Right=�6L   $	��854��6h   $��	0,0,12,69q�6t   
������� �� View 5      �� 5      .P�5      ��  �� Width$	 180��6%   $��Cliente��61    �� DisplayMemberBinding 6B   �� 	 �� Path$
	 Name��� 5      $	 140��6%   $��Precio Proveedor��61    6K   �� $	 ProviderPrice�5      �� 5      $	 140��6%   $��Precio Cliente��61   
 �� CellTemplate
 5      �� 5      .R�5   "   �� .+�5   &   �� -   5        $	��130��5   P   ��6.   �� $	 ClientPrice�6{   5   #   5      5      �� 5      $ 90��6%   $��	Beneficio��60    6C   �� $	 Profit�5!      �� 5"      $ 90��6%   $��Enviar Correo?��60   
 5#      �� 5$      .R�5%   "   ��  d� 	IsChecked 6+   �� $	 	SendEmail�5&      5(      �� 5)      $	 100��6%   $��Solicitar Producto��61   
 5*      �� 5+      .R�5,   "   ��  6+   �� $	 RequestProduct�5-      5/      �� 50      $	 110��6%   $��Eliminar Busqueda��61   
 51      �� 52      .R�53   "   ��  6,   �� $	 DeleteSearch�54      56      58      5:      �� 5;   
   -   5        $��button1��5;   _   $��Aceptar��6   $��23��6#   $
��Left=�6/   $��575,226,0,0q�6J   $	��Top=�6n   $��75��6�   6�   5<      5=      