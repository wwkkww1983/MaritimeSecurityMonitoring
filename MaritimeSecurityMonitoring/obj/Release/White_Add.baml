   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  *    $MaritimeSecurityMonitoring.White_Add   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:MaritimeSecurityMonitoring     -     � Title$  新增白名单信息��$	��650��$	��650��$	��650��$	��400��$	��400��$	��400�� � WindowStyle$
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
�������.��新增白名单信息�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������  �� Color$ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��4.2* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��40 40 40 30q�._��  �� $
��0.3* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��0.4* � � ColumnDefinitions �� $
��0.2* ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��0.2* �.+��� $��1��$��1��$��20(�$��Center=�$��0 0 8 0q�船舶MMSI编码�� -   $
��mmsi��$��1��$��2��$��20(�
������ $��Center=�$��Center=� �� 	MaxLength$ 11���� $��1��$��3��$��20(�$��Center=�$��35 0 0 0q�	船舷号�� -   $��number��$��1��$��4��$��20(�
������ $��Center=�$��Center=�$ 20���� $��2��$��1��$��20(�$��Center=�IMO�� -   $	��imo��$��2��$��2��$��20(�
������ $��Center=�$��Center=�$ 11���� $��2��$��3��$��20(�$��Center=�$��35 0 0 0q�呼号�� -   $��callSign��$��2��$��4��$��20(�
������ $��Center=�$��Center=�$ 64���� $��3��$��1��$��20(�$��Center=�船舶名称�� -   $
��name��$��3��$��2��$��20(�
������ $��Center=�$��Center=�$ 64���� $��3��$��3��$��20(�$��Center=�$��	35 0 10 0q�船舶部门�� -	   $��
department��$��3��$��4��$��20(�
������ $��Center=�$��Center=�$ 64���� $��4��$��1��$��20(�$��Center=�船舶用途�� -
   $��usage��$��4��$��2��$��20(�
������ $��Center=�$��Center=�$ 64��� $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��35��$��90��$��20(�
�������$	��Top=�$��0 0 80 0q�.��确定�� -   $��2��#��[ $��35��$��90��$��20(�
�������$	��Top=�.��取消