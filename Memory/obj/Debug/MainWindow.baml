   M S B A M L   `   `   `  ����A  =Memory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Memory.ViewModelMemory.ViewModel  5   	       Memory.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Memory.ViewModel     5   	   -   5          � Title$  
MainWindow��5   	   $	��900��6   $
��1430��6)    � 
ResizeMode$ NoResize=�5
   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� CornerRadius �� Path��%  '��       '�� �    �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � �� 5      �� 5      .R�5      �� 
���   �$��1q�65   $ 5��5   !   $��5q�62   ._�5       �� $	��180��6%   $	��180��5!   %   $��local:Commands.FlipCard��5"   %   {�. ��6X   �� $ Index�.��5%   "   �� $
��Fill=�5&   (   $	��180��5'   (   $	��180��5(   (   ��5%   (   �� $
 View�5(   (   5+      5,      5-      5/      �� 52       � �� 53      �� 54      .R�55      � 56      58      �� 5;       � ��$ Disabled=�6K   5<      5=      �� 5@   
   " ��6   .�5A      ��  � ��$ 75��6&   63   �� 5B       � ��$ 30��6'   64   5C      5E      .��5G      ]� ��. .+�5I   
   �� $	��Top=�6   $��
20,20,0,10q�5J       �� Orientation$ 
Horizontal=�5K      $
��Left=�5L      .+�5O      �� $��Player Name: ��6   �� 5P      ��6   �� *
PlayerName+�� 5R      $��Time Played: ��6   $��	20, 0,0,0q�5S      �� 5U      $	��150��5V      $��75��5W      ��5U      �� *Clock.ElapsedTime+5W      �� 5Z      $��Tries: ��6   $��20,0,0,0q�5[      �� 5]      ��6   �� $ Tries�5_      �� 5b   
   $��Right=�6   $��20, 50, 20,20q�6,   .+�5d      �� $��Start��6   $��local:Commands.StartGame��5e      {�. 5f      �� 5h      $��Top 5��6   $��0,15,0,0q�5i      �� 5k      $	��150��6   $	��400��5l      �� 5o      $��Restart��6   $��	0,20,0,20q�5p      $ ��local:Commands.RestartGame��5q      {�. 5r      �� 5u      $
��Exit��6   $��local:Commands.ExitGame��5v      {�. 5w      5z      �� 5}   
   ��6   �� *Cards+5~      5      5�      