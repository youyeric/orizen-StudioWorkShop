 <?php 
	header('Content-type: text/html; charset=utf-8');
	if(isset($_GET['num'])){
	selectSome($_GET['num']);
	}
	else{
		selectAll();
	}
	function selectAll(){
	$servername = "localhost";
	$username = "adminZfwTxW8";
	$password = "5-kq1fKFHbtE";
	$dbname = "studiogame";
	$index = 0;
		$conn = new mysqli($servername, $username, $password, $dbname);
	if ($conn->connect_error) {
		die("Connection failed: " . $conn->connect_error);
	}
	$sql = "SELECT * FROM Card";
	$result = $conn->query($sql);

	while($row =$result->fetch_assoc()){
		echo $row["CardNumber"].",".$row["CardName"].",".$row["CardLifePoint"].",".$row["CardAttack"].",".$row["CardSpeed"].",".$row["AttackRange"].",".$row["AttackType"].",".$row["Gold"].",".$row["CardAttribute"].",".$row["CardPicturePath"]."/";
		$index++;
	}
	}
	function selectSome($num){
	$servername = "localhost";
	$username = "adminZfwTxW8";
	$password = "5-kq1fKFHbtE";
	$dbname = "studiogame";
	$card = array();
	$index = 0;
		$conn = new mysqli($servername, $username, $password, $dbname);
		if ($conn->connect_error) {
			die("Connection failed: " . $conn->connect_error);
		}
		$sql = "SELECT * FROM TarotCard Where CardNumber='$num'";
		$result = $conn->query($sql);
		while($row =$result->fetch_assoc()){
			$card[$index] = array("CardNumber"=>$row["CardNumber"] ,"CardName"=>$row["CardName"] ,"CardLifePoint"=>$row["CardLifePoint"] ,"CardAttack"=>$row["CardAttack"], "CardSpeed"=>$row["CardSpeed"], "AttackRange"=>$row["AttackRange"], "AttackType"=>$row["AttackType"], "Gold"=>$row["Gold"], "CardAttribute"=>$row["CardAttribute"], "CardPicturePath"=>$row["CardPicturePath"]);
		}
		$conn->close();
	 echo json_encode($card);
}
 ?>