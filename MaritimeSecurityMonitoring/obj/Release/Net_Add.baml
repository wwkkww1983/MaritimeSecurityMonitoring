   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  (    "MaritimeSecurityMonitoring.Net_Add   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:MaritimeSecurityMonitoring     -     � Title$  新增网络参数信息��$	��650��$	��650��$	��650��$	��360��$	��360��$	��360�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value 
 Cancel��%�  &	        &	 o     &	 f    �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2��  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��新增网络参数信息�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��3.6* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��40 40 40 30q�._��  �� $
��0.3* ��� $��* ��� $��* ��� $��* ��� $
��0.4* � � ColumnDefinitions �� $
��0.2* ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��0.2* �.+��� $��1��$��1��$��20(�$��Center=�$��0 0 15 0q�
设备IP�� -   $��ip��$��1��$��2��$��20(�
������ $��Center=�$��Center=��� $��1��$��3��$��20(�$��Center=�$��	35 0 10 0q�设备名称�� -   $
��name��$��1��$��4��$��20(�
������ $��Center=�$��Center=� �� 	MaxLength$ 20���� $��2��$��1��$��20(�$��Center=�	端口1�� -   $��port1��$��2��$��2��$��20(�
������ $��Center=�$��Center=��� $��2��$��3��$��20(�$��Center=�$��35 0 0 0q�	端口2�� -   $��port2��$��2��$��4��$��20(�
������ $��Center=�$��Center=��� $��3��$��1��$��20(�$��Center=�	端口3�� -   $��port3��$��3��$��2��$��20(�
������ $��Center=�$��Center=��� $��3��$��3��$��20(�$��Center=�$��35 0 0 0q�	端口4�� -	   $��port4��$��3��$��4��$��20(�
������ $��Center=�$��Center=�� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -
   $��1��#��[ $��35��$��90��$��20(�
�������$	��Top=�$��0 0 80 0q�.��确定�� -   $��2��#��[ $��35��$��90��$��20(�
�������$	��Top=�.��取消