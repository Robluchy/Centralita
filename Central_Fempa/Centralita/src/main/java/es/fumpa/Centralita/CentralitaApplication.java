package es.fumpa.Centralita;

import es.fumpa.Centralita.model.Departamento;
import es.fumpa.Centralita.model.Registro;
import es.fumpa.Centralita.model.Usuario;
import es.fumpa.Centralita.repository.DepartamentoRepository;
import es.fumpa.Centralita.repository.RegistroRepository;
import es.fumpa.Centralita.repository.UserRepository;
import org.apache.catalina.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class CentralitaApplication implements CommandLineRunner {
	@Autowired
	DepartamentoRepository departamentoRepository;

	@Autowired
	UserRepository userRepository;

	@Autowired
	RegistroRepository registroRepository;


	public static void main(String[] args) {

		SpringApplication.run(CentralitaApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		Departamento profesor = new Departamento("DAM");
		Usuario javier = new Usuario("javier", "perez", "2313213", "asdasdas", "123456", 212, profesor,false);
		Registro r1 = new Registro("12321","dsadsa","asdsa","dsad","sdsa","sdas","dsad",javier,javier);
		departamentoRepository.save(profesor);
		userRepository.save(javier);
		registroRepository.save(r1);
	}
}
