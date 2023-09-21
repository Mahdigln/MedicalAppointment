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
				'First-Name' => $_POST['firstName'],
				'Last-Name'	 => $_POST['lastName'],
				'Email'	  	 => $_POST['your_mail'],
				'Topic'   	 => $_POST['topic'],
				'Message' 	 => $_POST['your_message']
			)
	);
	
	// set message Info
	$obj->set_message(
		array(
			'First-Name' => $_POST['firstName'],
			'Last-Name'	 => $_POST['lastName'],
			'Email'	  	 => $_POST['your_mail'],
			'Topic'   	 => $_POST['topic'],
			'Message' 	 => $_POST['your_message']
		)
	);
	// Mail to
	$obj->mailto = 'yourmail@yourdomain.com'; // Replace your e-mail here
	// subject
	$obj->subject = $_POST['topic'];
	$obj->name = $_POST['firstName'];
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