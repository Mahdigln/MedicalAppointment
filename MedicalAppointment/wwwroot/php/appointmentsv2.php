<?php 
if( !$_POST  ){
	exit();
}
include( 'mailclass/AtelierMail.php' );

	// mail object
	$obj = new AtelierMail();
	// validation
	$obj->data_validation(
			array(
				'Full-Name'	  => $_POST['full_name'],
				'Date'	 => $_POST['date'],
				'Social-Security-Number'  => $_POST['socailsec'],
				'Email'	  => $_POST['email'],
				'Phone'   => $_POST['your_phone'],
				'Message' => $_POST['message']
			)
	);
	
	// set message Info
	$obj->set_message(
		array(
			'Full-Name'	  => $_POST['full_name'],
			'Date'	 => $_POST['date'],
			'Social-Security-Number'  => $_POST['socailsec'],
			'Email'	  => $_POST['email'],
			'Phone'   => $_POST['your_phone'],
			'Message' => $_POST['message']
		)
	);
	// Mail to
	$obj->mailto = 'yourmail@yourdomain.com'; // Replace your e-mail here
	// subject
	$obj->subject = 'Subject Test';
	$obj->name = $_POST['full_name'];
	$obj->email = $_POST['email'];
	
	$result = $obj->mail_execute();
	
	
	if( $result == true ){
		echo '<div class="alert alert-success">';
			echo "Message send Successfully<br>";
		echo '</div>';
	}else{
		echo '<div class="alert alert-danger">';
			echo "Message send failed <br>";
		echo '</div>';
	}
	if( $obj->error_message() ){
		echo $obj->error_message();
	}
	




?>