package com.fempa.web;

import com.fempa.web.model.Registro;
import com.fempa.web.model.Usuario;
import com.fempa.web.repositorios.RegistroRepositoy;
import com.fempa.web.repositorios.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class WebApplication implements CommandLineRunner {
	@Autowired
	UsuarioRepository userRepository;
	@Autowired
	RegistroRepositoy registroRepository;
	public static void main(String[] args) {
		SpringApplication.run(WebApplication.class, args);
	}
	@Override
	public void run(String... args) throws Exception {

		Usuario javier = new Usuario("Javier perez",  "a", "1", 212, true);
		Usuario miriam = new Usuario("Juanma perez", "b", "2", 212, false);
		Usuario juan = new Usuario("Dionny perez", "dionny@nunes.com","1232", 212, false);
		Usuario Contabilidad = new Usuario("Contabilidad", "dionny75@gmail.com", null, 655626262, false);
		Usuario Administracion = new Usuario("Administracion", "dionny0725@gmail.com", null, 655626262, false);

		Registro r1;
		r1 = new Registro(563434321,"dionny075@gmail.com","NTT","25/01/2023","llamada rechazada","Sergio","quiere registrarse",juan, miriam);
		Registro r2;
		r2 = new Registro(454324124,"dionny075@gmail.com","optiva","25/01/2023","atiende recepcion","Miguel","quiere registrarse",juan, javier);
		Registro r3;
		r3 = new Registro(454324124,"dionny075@gmail.com","optiva","25/01/2023","llamada pasada","Dionny","quiere registrarse",juan, miriam);
//
//		userRepository.save(javier);
//		userRepository.save(miriam);
//		userRepository.save(juan);
//		userRepository.save(Contabilidad);
//		userRepository.save(Administracion);
//
//		registroRepository.save(r1);
//		registroRepository.save(r2);
//		registroRepository.save(r3);

	}
}
