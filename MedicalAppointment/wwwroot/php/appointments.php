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
				'name'	  => $_POST['first_name'],
				'date'	  => $_POST['birth_date'],
				'gender'  => $_POST['gender'],
				'mail'	  => $_POST['your_mail'],
				'phone'   => $_POST['your_phone'],
				'message' => $_POST['your_message']
			)
	);
	
	// set message Info
	$obj->set_message(
		array(
			
			'Name' 	  => $_POST['first_name'],
			'Gender'  => $_POST['gender'],
			'Date' 	  => $_POST['birth_date'],
			'Mail' 	  => $_POST['your_mail'],
			'Phone'   => $_POST['your_phone'],
			'Message' => $_POST['your_message'],
		)
	);
	// Mail to
	$obj->mailto = 'yourmail@yourdomain.com'; // Replace your e-mail here
	// subject
	$obj->subject = 'Subject test';
	$obj->name = $_POST['first_name'];
	$obj->email = $_POST['your_mail'];
	
	$result = $obj->mail_execute();
	
	
	if( $result == true ){
		echo '<div class="alert alert-success">';
			echo "Message send Successfully<br>";
		echo '</div>';
	}else{
		echo '<div class="alert alert-danger">';
			echo "Message send failed.<br>";
		echo '</div>';
	}
	if( $obj->error_message() ){
		echo $obj->error_message();
	}
	




?>