   M S B A M L   `   `   `  ���� U  QMaritimeSecurityMonitoring, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullW0clr-namespace:MaritimeSecurityMonitoring.Content"MaritimeSecurityMonitoring.Content  +    %MaritimeSecurityMonitoring.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Dcontent0clr-namespace:MaritimeSecurityMonitoring.Content     -     �Name$
  main�� � Title$ 
MainWindow�� � Icon$ Image\SmallLogo.png��$	��550��$	��550��$	��550��$	��350��$	��350��$	��350�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=���Z�  � 	Resources    CornerCheckBox �� 
TargetType	 �� Bullet
 ��Name �� CornerRadius F�Name �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  DefaultButton  CornerButton  CornerTextBox ��Name  CornerPasswordBox 	 Login��%y  &	        &	 �    &	 |    &	 b    &	 �    &	 8    �� " ��.R��� $��LeftToRight=�$��15��$��Center=�$��Center=�	 �� $
 bd��$��0q�$��15��$��15�����#d8e2f0$ 3��._�F� $ cp��$��12��$��12�����#2e6ac6$��2��._���  P�  �@d�	IsChecked$
 TrueY�. ��� $ cp�� � ��" ��    ��[ р�[  � � �     	��  � �� �#2e6ac6P�  �@J�IsMouseOver . . ��� $ bd�� � ��
 ������� " ��.R��� $	
 bd0��$��0q�$ 3��
������ ._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $	 bd0�� � �� �	#FF5A97F3P�  � �� . . ��� $	 bd0�� � �� �	#FF005AE2�� " ��.R��� $	
 bd1��$��0q�$ 5�����#d8e2f0._��� #��z��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $	 bd1�� � ��
 �����P�  � �� . . ��� $	 bd1�� � ��
 ������� " ��.R��� $��0q����#d8e2f0$ 5��._��� $ PART_ContentHost��$��Center=�$��8 0 0 0q��� " G�.R��� $��0q����#d8e2f0$ 5��._��� $ PART_ContentHost��$��Center=�$��8 0 0 0q���  J� InputBindings �� 
 �� Key$ Return�� �� Command# [  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���� $��0q�$ 8������  �� ImageSource$" Image\LoginBackgroundNew.png��._�� $��4�� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��50��$
��Left=�$��10 8 0 0q�$��Image\Logo.png���� $��0��$��20(�
�������$
��Bold"�$��	70 20 0 0q�&$海上平台水面安防预警系统�� -   $��0��$��25��$��25��$��Right=�#��[ $��0 5 60 0q�.���� $��Image\Minimum.png���� -   $��0��$��25��$��25��$��Right=�#��[ $��0 5 20 0q�.���� $��Image\LoginClose.png���� $��1��$��28��$
��Left=�$��Bottom=�$��Image\User.png��$��
120 0 0 10q��� -    ��Name$ userName��$��1��#��[ $	��280��$��45��$��Bottom=�$��20(����#2e6ac6$��30 0 0 0q� �� 	MaxLength$ 20���� -   $��1��#��[ $��40��$��40��$��Right=�$��Bottom=�$��	0 0 120 2q�.���� $��45��$��Image\PullDown.png��� -    �Name$ userListPopup�� � 	StaysOpen .  ��.  $��Bottom=� � AllowsTransparency . $��Slide=�$	��100��  � PlacementTarget  �� ! �� ElementName$! userName��.��� .+��� -   $��userListView�����#d8e2f0$��20(����#2e6ac6$��1q����#2e6ac6$��Disabled=�����  " �� 
TargetType��%4   '��       �� "" ��.���  � y�$ 	Collapsed=�# �� View# �� .P��� $ �� Width$	$ 270��% �� DisplayMemberBinding% �� & �� Path$& 
UserNumber��� $��2��$��28��$
��Left=�$��Image\Password.png��$��	117 0 0 0q�G� -	   ' G�Name$' password��$��2��#��[ $	��280��$��45��$��20(����#2e6ac6$��30 5 0 0q�( G� 	MaxLength$( 20���� -
   $��2��#��[ $��40��$��40��$��Right=�$��Bottom=�$��	0 5 120 2q�.���� $��26��$��Image\Keyboard.png��� -   $ keyboardPopup�� .  ��.  $��Bottom=�) � HorizontalOffset$	) -20�� . $
��Fade=�  �� $! password��.��1   +MaritimeSecurityMonitoring.Content.KeyBoard  -   *  Name$* keyboard��1   +MaritimeSecurityMonitoring.Content.KeyBoard+   Click$+ keyboardBtn_Click���� -   $��rememberPassword��$��3��#��[  $
��Left=�$��
150 13 0 0q��� $��3��$��16(����#d8e2f0$��
175 13 0 0q�记住密码�� -   $��extendScrean��$��3��#��[  $
��Left=�$��
340 13 0 0q��� $��3��$��16(����#d8e2f0$��
365 13 0 0q�双屏模式�� 2  ,System.Windows.Markup.XmlAttributeProperties,  XmlSpace, preserve-   $��4��#��[ $	��280��$��40��$��20(����#2e6ac6$��
30 13 0 30q�.��登       录