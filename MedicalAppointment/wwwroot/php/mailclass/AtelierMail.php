<?php 
class AtelierMail{
	
	public $mailto;
	public $subject;
	public $message;
	public $name;
	public $email;
	public $error;
	public $is_ok;
	
	
	//
	public function mail_execute(){
		
		$from_user = $this->name;
		$from_email = $this->email;
		// header 
		// Always set content-type when sending HTML email
		$headers = "MIME-Version: 1.0" . "\r\n";
		$headers .= "Content-type:text/html;charset=UTF-8" . "\r\n";

		// More headers
		$headers .= "From: $from_user <$from_email>" . "\r\n";
		// mail 
		if( $this->is_ok == true ){
			$mail = mail( $this->mailto , $this->subject, $this->message, $headers );
			
			if( $mail ){
				return true;
			}else{
				return false;
			}
		}else{
			return false;
		}
		
		
	}
	
	public function set_message( $data = array() ){
		$message = "";
		$message .= "<html>";
		$message .= "<body>";
		$message .= "<table>";
		foreach( $data as $key => $value){
			$message .= "<tr>";
					$message .= '<th>'.$key.'</th>';
					$message .= '<th>'.$value.'</th>';
			$message .= "</tr>";
		}
		$message .= "</table>";
		$message .= "</body>";
		$message .= "</html>";
		
		$this->message = $message;
	}
	// field validation check
	public function data_validation( $data = array() ){
		
		$is_ok = true;	
		$error = "";		
		foreach( $data as $key => $value ){
			
			if(  empty($value) ) {
				$error .= $key. ' field cannot be empty.<br>';
				$is_ok = false;
			}
		}
		
		$this->error = $error;
		$this->is_ok = $is_ok;
	}
	
	public function error_message(){
		
		$error = "";
		if( $this->error ){
			$error .=  '<div class="alert tr alert-danger">';
			$error .= $this->error;
			$error .= '</div>';
		}
		
		return $error;
	}
	
}
?>