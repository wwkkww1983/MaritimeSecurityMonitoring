   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null6    0MaritimeSecurityMonitoring.DeviceOperationStatus   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  DeviceOperationStatus��   
CommonPage#��[   � 	Resources   SwitchButton0 �� 
TargetType �� Property �� Value �� 
TargetType � ColumnDefinitions �Name �� Stretch	 � Points
 ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName  SwitchButton  SwitchButton1��%  &	       &	 �    &	     �� " ��.���  � �� �� " ��.R��  �� $
��0.5* ��� $
��0.5* ��� $��0.45* �.+�� $	 plg��$��1��$��2��$
 Fill=����	#FF6EB5DC	 �   �~  � �� $
 bd��$��0��$��2��$��0q����	#FF6EB5DC$ 8 0 0 8��._���  P�  �@J�IsMouseOver . . ��� $ bd�� � ��
 ������� $	 plg�� � ��
 �����P�  � �� . . ��� $ bd�� � ��
 ������� $	 plg�� � ��
 ������� " ��.���  � ��$ 50����  � ��$ 93.75����  � �� �� " ��.R�� $��
-22 0 22 0q�.+�� $	 plg��$
 Fill=����	#FF6EB5DC	 �   �� p{ �� ��  P�  �@J�IsMouseOver . . ��� $	 plg�� � ��
 �����P�  � �� . . ��� $	 plg�� � ��
 ������� " ��.���  � �� �� " ��.R��  �� $��0.45* ��� $
��0.5* ��� $
��0.5* �.+�� $	 plg��$��0��$��2��$
 Fill=����	#FF6EB5DC	 �   �� �~ �~ �� $
 bd��$��1��$��2��$��0q����	#FF6EB5DC$ 0 8 8 0��._���  P�  �@J�IsMouseOver . . ��� $ bd�� � ��
 ������� $	 plg�� � ��
 �����P�  � �� . . ��� $ bd�� � ��
 ������� $	 plg�� � ��
 �����.��� $��5q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0��$��0q����#d9ebf6$ 8��$
��Left=�$��0 0 0 5q�$	��500�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$
 Gray��   Opacity$	 0.6Q�._�� $��Right=�.+��� -   #��[ $��50��$��81.25�� � ToolTip$ AIS工作状态��.���� $��Image\AIS.png��$��	10 10 6 6q��� -   #��[ $ 雷达工作状态��.���� $��Image\radar.png��$��6q��� -   #��[ $1 +                         设备工作状态��$��	-22 0 0 0q�.���� $%��Image\Optoelectronic Device.png��$	��6 7q��� -   #��[ $ 监控主机1状态��$��	-22 0 0 0q�.���� $��Image\监控主机.png��$��6q��� -   #��[ $ 监控主机2状态��$��	-22 0 0 0q�.���� $��Image\监控主机.png��$��6q��� -   #��[ $ 融合服务器状态��$��	-22 0 0 0q�.���� $��Image\MixServer.png��$	��6 8q��� -   #��[ $��50��$��81.25��$ 数据库服务器状态��$��	-44 0 0 0q�.���� $��Image\MixServer.png��$	��6 8q� � -   $��content��$��1��  � Source$ page/AISPage.xaml?�