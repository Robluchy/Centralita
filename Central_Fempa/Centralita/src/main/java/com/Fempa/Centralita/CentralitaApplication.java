package com.Fempa.Centralita;

import com.Fempa.Centralita.model.Departamento;
import com.Fempa.Centralita.model.Registro;
import com.Fempa.Centralita.model.Usuario;
import com.Fempa.Centralita.repository.DepartamentoRepository;
import com.Fempa.Centralita.repository.RegistroRepository;
import com.Fempa.Centralita.repository.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class CentralitaApplication implements CommandLineRunner {
	@Autowired
	DepartamentoRepository departamentoRepository;
	@Autowired
	UsuarioRepository userRepository;
	@Autowired
	RegistroRepository registroRepository;

	public static void main(String[] args) {
		SpringApplication.run(CentralitaApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		Departamento conserge = new Departamento("conserge");
		Departamento contabilidad = new Departamento("contabilidad");
		Departamento profesor = new Departamento("profesor");

		Usuario javier = new Usuario("Javier", "perez", "X21232222", "javier@faus.com", "123456", 212, profesor, false);
		Usuario miriam = new Usuario("Miriam", "perez", "X55553215", "miriam@perez.com", "123456", 212, contabilidad, false);
		Usuario juan = new Usuario("Juan", "perez", "X2313213z", "juan@perez.com","123456", 212, conserge, false);

		Registro r1;
		r1 = new Registro("56345234321","sergio@gmail.com","NTT","25/01/2023","llamada rechazada","Sergio","quiere registrarse",juan, miriam);
		Registro r2;
		r2 = new Registro("454324124","miguel@gmail.com","optiva","25/01/2023","atiende recepcion","Miguel","quiere registrarse",juan, javier);
		Registro r3;
		r3 = new Registro("454324124","dionny@gmail.com","optiva","25/01/2023","llamada pasada","Dionny","quiere registrarse",juan, miriam);

//		departamentoRepository.save(conserge);
//		departamentoRepository.save(contabilidad);
//		departamentoRepository.save(profesor);
//
//		userRepository.save(javier);
//		userRepository.save(miriam);
//		userRepository.save(juan);
//
//		registroRepository.save(r1);
//		registroRepository.save(r2);

	}
}
