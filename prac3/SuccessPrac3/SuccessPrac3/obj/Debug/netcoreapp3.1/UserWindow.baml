   M S B A M L   `   `   `  ����G  CSuccessPrac3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SuccessPrac3SuccessPrac3  5   	       SuccessPrac3.UserWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SuccessPrac3     5   	     � Title$  
UserWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $��Log in��6   $
��Left=�6!   $��
106,12,0,0q�6<   $	��Top=�6P   $��20(�6h   �� 5   
   $��Register��6   $
��Left=�6#   $��
581,12,0,0q�6>   $	��Top=�6R   $��20(�6j   �� 5   
   $
��Edit��6   $
��Left=�6   $��117,190,0,0q�6:   $	��Top=�6O   $��20(�6g   �� 5   
   $
��Name��6   $
��Left=�6   $��
471,80,0,0q�6:   $	��Top=�6N   �� 5   
   $��Surname��6   $
��Left=�6"   $��463,129,0,0q�6=   $	��Top=�6R   �� 5   
   $��LogIn��6   $
��Left=�6    $��471,169,0,0q�6;   $	��Top=�6P   �� 5   
   $��Password��6   $
��Left=�6#   $��461,209,0,0q�6>   $	��Top=�6S   �� 5   
   $��Repeat Password��6   $
��Left=�6*   $��442,241,0,0q�6E   $	��Top=�6Z   �� 5   
   -   5         ��Name$ 	NameField��5      $
��Left=�6%   $��
562,80,0,0q�6@   $�� ��6T    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��120��6�   �� 5   
   -   5        $ SurnameField��5      $
��Left=�6(   $��562,129,0,0q�6C   $�� ��6X   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5   
   -   5        $ loginRegField��5      $
��Left=�6)   $��562,172,0,0q�6D   $�� ��6Y   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5   
   $��LogIn��6   $
��Left=�6    $��	67,81,0,0q�6;   $	��Top=�6N   �� 5   
   $��Password��6   $
��Left=�6#   $��
57,121,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $ 
loginField��5      $
��Left=�6&   $��
158,84,0,0q�6A   $�� ��6U   $
 Wrap=�6]   $	��Top=�6q   $	��120��6�   �� 5   
   $
��Name��6   $
��Left=�6   $��
67,232,0,0q�6:   $	��Top=�6N   �� 5   
   $��Surname��6   $
��Left=�6"   $��
59,263,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5        $ NewNameField��5      $
��Left=�6(   $��158,232,0,0q�6C   $�� ��6X   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5   
   -   5        $ NewSurnameField��5      $
��Left=�6+   $��158,263,0,0q�6F   $�� ��6[   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5   
   $��New Password��6   $
��Left=�6'   $��
44,289,0,0q�6B   $	��Top=�6V   �� 5   
   $��Repeat New Password��6   $
��Left=�6.   $��
23,318,0,0q�6I   $	��Top=�6]   �� 5   
   -   5         ��Name$ AutorBtn��5      $��LogIn��6#   $
��Left=�63   $��118,157,0,0q�6N   $	��Top=�6c    J� RenderTransformOrigin$ 0.522,0.603&�6{   6�   �� 5   
   -   5        $ UpdateDataBtn��5      $��Update��6(   $
��Left=�69   $��115,372,0,0q�6T   $	��Top=�6i   6�   �� 5    
   -	   5        $ RegBtn��5       $��Register��6!   $
��Left=�64   $��582,320,0,0q�6O   $	��Top=�6d   6|   G� 5!   
   -
   5         G�Name$ passwdField��5!      $
��Left=�6+   $��158,125,0,0q�6F   $	��Top=�6[   $	��120��6s   G� 5"   
   -   5        $ NewPasswdField��5"      $
��Left=�6.   $��158,293,0,0q�6I   $	��Top=�6^   $	��120��6v   G� 5#   
   -   5        $ NewPasswdField2��5#      $
��Left=�6/   $��158,322,0,0q�6J   $	��Top=�6_   $	��120��6w   G� 5$   
   -   5        $ passwdRegField��5$      $
��Left=�6.   $��562,213,0,0q�6I   $	��Top=�6^   $	��120��6v   G� 5%   
   -   5        $ passwdRegField2��5%      $
��Left=�6/   $��562,245,0,0q�6J   $	��Top=�6_   $	��120��6w   5'      5(      