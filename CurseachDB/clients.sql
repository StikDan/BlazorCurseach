use Marketplace;
SET SQL_SAFE_UPDATES = 0;

CREATE TRIGGER update_passwords_in_sha 
BEFORE UPDATE ON client
	FOR EACH ROW
	SET NEW.password = SHA(NEW.password);
    
CREATE TRIGGER insert_passwords_in_sha 
BEFORE INSERT ON client
	FOR EACH ROW
	SET NEW.password = SHA(NEW.password);
    
CREATE TRIGGER update_default_client_role 
BEFORE INSERT ON client
	FOR EACH ROW
	SET NEW.idRole = 1;

#update client
#SET password = "111"
#WHERE idClient = 1;

#update client
#SET password = "alaska"
#WHERE idClient = 2;

SELECT * FROM marketplace.client;