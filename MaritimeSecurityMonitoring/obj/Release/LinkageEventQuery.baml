   M S B A M L   `   `   `  ���� H  DNVRCsharpDemo, Version=2.0.1.1, Culture=neutral, PublicKeyToken=nullD2clr-namespace:NVRCsharpDemo;assembly=NVRCsharpDemoNVRCsharpDemo  ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms U QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring 2   ,MaritimeSecurityMonitoring.LinkageEventQuery   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     BDVR2clr-namespace:NVRCsharpDemo;assembly=NVRCsharpDemo     _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:MaritimeSecurityMonitoring       N� Title$  LinkageEventQuery��   
CommonPage#��[   � 	Resources  �� 
TargetType �� Property �� Value  CornerButton �� 
TargetType ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName  CheckButton � ColumnDefinitions �� Stretch � Points �� 
StartPoint �� EndPoint � Color � Offset  TimeCheckButton  TextBoxErrorTemp �� Triggers �� ElementName �� Path��%�  '��       '�� S     &	 �     &	 �    &	 j    &	 ]    �� " ��.���  � ��$ Center=���  � ��$ 14(���  � ��$ 30���� " ��.���  � ��
 ���� ��  � ��$ 15(���  � ��$ 30���� " ��.R��� $ bd��$��0q�$ 5��
������ ._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $ bd�� � ��
 �����P� 	 � ��
 . . ��� $ bd�� � ��
 ������� " ��.R��� $	 bd1��$��1q����	#FFA3C5EE
������ $ 5��._��  �� $��* ��� $
��1.4* �.+�� $��0��$
 Fill=�9 �   ��- `� ��  	=  	= @T� ���  	= ��[ $��6 6 0 6q����� $	 0,1&�$	 1,0&�.��� $ 	#FF007CC3��$ 0Q�� $ 	#FF6EB5DC��$	 0.8Q��� $��1��$��Center=�$��Center=�$��0 0 4 0q� P� 	 �@J�IsMouseOver
 . . ��� $	 bd1�� � ��
 �����P� 	 � ��
 . . ��� $	 bd1�� � ��
 ������� " ��.R��� $	 bd2��$��1q����	#FFA3C5EE$ 3��
������ ._��� #��z��$��Center=�$��Center=� P� 	 �@J�IsMouseOver
 . . ��� $	 bd2�� � ��
 �����P� 	 � ��
 . . ��� $	 bd2�� � ��
 ������� " �� P� 	 �@=�HasError
 . . ���  �@=�ErrorTemplate �� .R�]� ��. .+��� $��Bottom=�
���  ��$��14(�$
��Bold"�$��Center=����� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��2q�$��53��._��� $��	MyAdorner��.��� $��20 15q� � RowDefinitions �� $��60 ��� $��* �.+��� $��0��  CommonGroupBox#��[ $��选择时间��.���� .+�/  )MaritimeSecurityMonitoring.DateTimePicker  -     Name$ 	StartTime��   Title$ 开始时间：��$	��280��$��30��
 �� Top$ 14�� �� Left$	 200���� $��28��$��2��$��1q����	#FFA3C5EE$ 29��$	 520��  -   $ EndTime��$ 结束时间：��$	��280��$��30��$ 14��$	 590���� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve-   #��[ $��16(�$��70��$��30��$ 14��$	 910��.��
确  定� $��1��$��0 15 0 0q� �� $
��1.4* ��� $��* �.+��� $��0��#��[ $��联动视频��$��0 0 20 0q�.���  �� $��* ��� $	��135 �.+�� $��0��$��0 40 0 0q� �� $��* ��� $
��Auto ��� $��* �.+��� $��0q�$ 8��$��3��$
��51,0q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$
 Gray��   	Direction$	 -50Q�   Opacity$	 0.5Q�    ShadowDepth$  5Q����� $	 0,0&�$	 1,1&�.��� $ 	#FF6EB5DC��$ 0Q�� $ #d9ebf6��$ 1Q�._��  �� $��* ��� $��35 �.+�7  1System.Windows.Forms.Integration.WindowsFormsHost  $��0��$��3,3,3,3q�!   Child.!    NVRCsharpDemo.mypanel  -   infraredRayPictureBox��"  System.Windows.Forms.Control"   Margin+  %System.Windows.Forms.PaddingConverter$" 0,0,0,0 �� -   # ��Name$# mediaBtn��$��0��  MediaInterfaceButton#��[ $��70��$��70��.��� $
 Fill=�9 �    �  � `��  � ��� ��� `�S ���  �D 
���   �$ J� Opacity$	$ 0.5Q�$��5 0 0 0 q�� $��1�� �� $
��Auto ��� $��* ��� $
��Auto �.+��� -   % ��Name$% minute��$��0��$��14(����	#FF4B4B4B$��Center=�$��25 0 0 0q�00 :�� -   $% second��$��0��$��14(����	#FF4B4B4B$��Center=�$��	53 0 15 0q�00�� -   & ��Name$& sliderPosition��$��1��  Slider_CustomStyle#��[ ' � LargeChange$' 10Q��� -	   $# voiceBtn��$��2��  VoiceButton#��[ $
��22.5��$��25��$��	20 0 25 0q�$y�Hidden=�� -
   ( �Name$( 
voicePopup��$��2��) � 	StaysOpen) .  ��.  $	��Top=�* � VerticalOffset$	* -10��+ � HorizontalOffset$+ 3��, � AllowsTransparency, . - � PlacementTarget- �� $ voiceBtn��.���� -   $& VolumnSlider�� 	 Slider_VerticalStyle#��[	 . �� Orientation$. Vertical=�$	��100��/ � Maximum$/ 1Q�$	' 0.1Q�0 � Value0 �� *Volume+$ mediaElement��1 �� Mode$1 TwoWay=�2 �� UpdateSourceTrigger$2 Default=�� $��1��$��0 0 0 15q� �� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $# stopBtn��$��1�� 
 MediaButton#��[
 3 � ToolTip$3 停止播放��$��40��$��40��$��	13 6 13 0q�.���� 
�������$ 2��$	��1.2q�   $
 Gray��$	 -50Q�$	 0.8Q�$  1Q��� -   $# backBtn��$��2��#��[
 $3 慢速播放��$��40��$��40��$��	13 6 13 0q�.��� -   4 �Name$4 BackPolygon��$
 Fill=�q �   ��A  u8 ��V ��[ �� ��[ �%& �� ��� �� ���  ~u ��  z ��[ `�S ��[  ~u ��V  z $��-1.5,0,1.5,0q����� 5 �� Color$5 White��   $
 Gray��$	 -50Q�$	 0.8Q�$  1Q��� -   $# pauseBtn��$��3��#��[
 $3 暂停播放��$��50��$��50��$y�	Collapsed=�$
��13 0q�.���  �� $��* ��� $��* �.+��� $��0��$
 Fill=�
�������$��2q�   $
 Gray��$	 -50Q�$	 0.8Q�$  1Q��� $��1��$
 Fill=�
�������$��2q�   $
 Gray��$	 -50Q�$	 0.8Q�$  1Q��� -   $# playBtn��$��3��#��[
 $3 开始播放��$��50��$��50��$y�Visible=�$
��13 0q�.��� -   $4 PlayPolygon��$
 Fill=�9 �    �  � `��  � ��� ��� `�S ���  �D $��5 1 0 1q����� $5 White��   $
 Gray��$	 -50Q�$	 0.8Q�$  1Q��� -   $# 
forwardBtn��$��4��#��[
 $3 快速播放��$��40��$��40��$��	13 6 13 0q�.��� -   $4 ForwardPolygon��$
 Fill=�q �   �� ��  	= �%&  	= �� ��A ���  u8 ��� ��A ��A  z  	=  ~u  	= `�S ��  z  ~u $��1.5,0,-1.5,0q����� $5 White��   $
 Gray��$	 -50Q�$	 0.8Q�$  1Q��� -   $# nextBtn��$��5��#��[
 $3 单帧播放��$��40��$��40��$��	13 6 13 0q�.���  �� $��* ��� $
��2.5* �.+��� $��0��$
 Fill=�
�������$��1 0.2q�   $
 Gray��$	 -50Q�$	 0.8Q�$  1Q�� $��1��$
 Fill=�9 �    �  � `��  � ��� ��� `�S ���  �D $��2 0.3 -2 -0.3q����� $5 White��   $
 Gray��$	 -50Q�$	 0.8Q�$  1Q��� $��1��#��[ $��联动列表��$��20 0 0 0q�.���  �� $��* ��� $	��135 �.+��� $��0��  CommonBorder#��[ $��
25 40 25 0q�._�� $��5q� �� $
��1.2* ��� $
��1.2* ��� $��* ��� $
��0.8* ��� $
��1.8* �.+�� -   6 �Name$6 column1��$��0��� -   $6 column2��$��1��� -   $6 column3��$��2��� -   $6 column4��$��3��� -   $6 column5��$��4���� -   $��LinkageListView��$��5��
������ $��0q�$
��-3 0q����� 7 �� View7 �� .P��� $��开始时间��8 �� Width8 �� $ column1��$ ActualWidth�9 �� DisplayMemberBinding9 �� *	StartTime+�� $��结束时间��8 �� $ column2��$ ActualWidth�9 �� *	EndTime+�� $��联动目标��8 �� $ column3��$ ActualWidth�9 �� *Target+�� $��	船舷号��8 �� $ column4��$ ActualWidth�9 �� *Number+�� $��图片路径��8 �� $ column5��$ ActualWidth�9 �� *	ImagePath+� $��1��$��0 0 0 5q� �� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��1��#��[ $��80��$��35��$��16(�$��0 0 20 0q�.��确认�� $��2��$��35��$	��300��$��1q����	#FFA3C5EE$ 6��._�� $��6�� �� $��* ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� -   $��0��#��[ $��16(�.��	首 页�� $��1��$��1��$��20��$��1q����	#FFA3C5EE�� -   $��2��#��[ $��16(�.��	上一页�� $��3��$��1��$��20��$��1q����	#FFA3C5EE�� -   $��4��#��[ $��16(�.��	下一页�� $��5��$��1��$��20��$��1q����	#FFA3C5EE�� -   $��6��#��[ $��16(�.��	尾 页� $��3��$��Center=�$��20 0 0 0q�.+��� -    $��20��$��20��
������ $��0q�.���� $��Image\PageSearch.png���� $��14(�$��Center=�$��5 0 0 0q�到�� -!   : ��Name$: 
pageNumber��#��[ $��20��$��50��$��14(�
������ $��0 0 0 1q����	#FFA3C5EE$��Center=�$��5 0 0 0q�.������ $ number�$1 TwoWay=�$2 PropertyChanged=�; �� NotifyOnValidationError; . < �� ValidationRules< ;  5MaritimeSecurityMonitoring.NumberValidationRuleForInt  -"   rule��
=   Max$= 1��
>   Min$> 1��.���� -#   $��currentPage��$��14(�$��Center=�$��5 0 0 0q�1�� $��14(�$��Center=�$��5 0 0 0q�/�� -$   $��
totalPages��$��14(�$��Center=�$��5 0 0 0q�1�� $��14(�$��Center=�$��5 0 0 0q�页