   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null+    %MaritimeSecurityMonitoring.QueryTrack   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  航迹查询��$	��450��$	��450��$	��450��$	��480��$	��480��$	��480�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources    CornerLabel �� 
TargetType �� CornerRadius  CornerButton ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value  	TriButton �� Stretch � Points �� Color �� 
TargetType 
 Cancel��%  &	        &	 o     &	 f    '��      &	 �    �� " ��.R��� $��0q�$ 8,8,0,0�����	#FF4A79D8._��� #��z��$
��Left=�$��Center=�$��10 0 0 0q��� " ��.R��� $ bd��$��0q�$ 5 5 5 5�����	#FF4A79D8._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � �� �	#FF6D9DFFP� 	 � ��
 . . ��� $ bd�� � �� �	#FF005AE2�� " d�.R��� $	 bd1��$��1q����	#FFAAAAAA
�������._�� $
 Fill=� �   ��� @KL ��� $
��4 10q����� $ Black�� P� 	 �@J�IsMouseOver
 . . ��� $	 bd1�� � �� �	#FFA9D7FF�� $	 bd1�� � �� �	#FF3C6DC3P� 	 � ��
 . . ��� $	 bd1�� � �� �	#FFA1CDF3P� 	 �@d�	IsChecked$

 TrueY�. ��� $	 bd1�� � �� �	#FFA1CDF3�� $	 bd1�� � �� �	#FF3C6DC3�� " ��.���  � �� �� " ��.R��� $	 bd1��$��1q�._��� #��z��$
��Left=�$��Center=�$��8 2 0 2q� P� 	 �@J�IsMouseOver
 . . ��� $	 bd1�� � ��
 �������  J� InputBindings �� 
 �� Key$	 Esc�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���  � RowDefinitions �� $��40 ��� $��* �.+��� #��[  $��20(�
�������.��航迹查询�� -   $��22��$��22��$��0 0 10 0q�$��Right=�$��0q�.���� $��Image/Close_new.png������ $ 	#FF4A79D8���� $��1��$��0q�
�������$ 0 0 8 8��._��  �� $
��4.8* ��� $��* �.+��� $��0��$��1q�
�������$ 8��$��50 40 50 35q�._��  �� $
��0.3* ��� $��* ��� $��3* ��� $
��0.4* �.+�� $��1��$��Center=�.+�	� -   $��20(�$��Center=� d� 	IsChecked$
 TrueY�$
��21 0q�.��	雷达1	� -   $��20(�$��Center=�$��0 0 21 0q�.��	雷达2	� -   $��20(�$��Center=�$��0 0 21 0q�.��AIS	� -   $��20(�$��Center=�.��融合� $��2�� �� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $
��1.8* �.+��� $��0��$��0��$��20(�$��Center=�$��Center=�$��20 0 0 0q�开始时间&   Xceed.Wpf.Toolkit.DateTimePicker  -   $��	startTime��$��0��$��1���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ShowButtonSpinner .  ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .     MouseWheelActiveOnFocus . $��16(�$��Center=�&   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�   FormatString$ yyyy-MM-dd HH:mm:ss��   
TimeFormat$ LongTime=�$��5 0 32 0q��� $��1��$��0��$��20(�$��Center=�$��Center=�$��20 0 0 0q�结束时间  -	   $��endTime��$��1��$��1�� .   .   . $��16(�$��Center=�$ Custom=�$ yyyy-MM-dd HH:mm:ss��$ LongTime=�$��5 0 32 0q��� $��2��$��0��$��20(�$��Center=�$��Center=�$��20 0 0 0q�查询目标�� -
     ��Name$  target��$��2��$��1��$��18(�$��Center=�! �� 
IsReadOnly! . $��5 0 32 0q�d� -   $��2��$��1��#��[ $��19��$��Center=�$��Right=�$��0 0 32 0q����� " �� ElementName$" target��# �� Path$# ActualHeight� �� $" targetPopup��$# IsOpen�� -   $ �Name$$ targetPopup��$��2��$��1��% � 	StaysOpen% .  ��.  $��Bottom=�& � AllowsTransparency& . $��Slide=�$	��125��' � PlacementTarget' �� $" target��.��� $	��186��.+��� -   $��targetListBox��
�������
���   �$��18(�$��1q�
����������� � $��1�� �� $��* ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��35��$	��100��$��20(�
�������$	��Top=�$��0 0 70 0q�.��确定�� -   $��2��#��[ $��35��$	��100��$��20(�
�������$	��Top=�.��取消