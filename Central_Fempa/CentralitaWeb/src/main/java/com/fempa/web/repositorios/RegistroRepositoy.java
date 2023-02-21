package com.fempa.web.repositorios;

import com.fempa.web.model.Registro;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface RegistroRepositoy extends JpaRepository<Registro, Long>{
}
